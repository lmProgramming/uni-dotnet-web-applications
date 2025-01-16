using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Identity.Utilities;
using Microsoft.AspNetCore.JsonPatch.Internal;

namespace Identity.Controllers
{
    public class ShopController : Controller
    {
        private readonly ArticleDbContext _context;

        public ShopController(ArticleDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            var categories = await _context.Categories.ToListAsync();
            if (categoryId is null)
            {
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
            }
            else
            {
                ViewBag.Categories = new SelectList(categories, "Id", "Name", categoryId);
            }

            var articles = await GetArticlesForPage(0, 16, categoryId);

            return View(articles);
        }

        public IActionResult AddToCart(int articleId)
        {
            string cookieKey = $"article{articleId}";
            if (Request.Cookies.ContainsKey(cookieKey))
            {
                int currentQuantity = int.Parse(Request.Cookies[cookieKey]!);
                Response.Cookies.Append(cookieKey, (currentQuantity + 1).ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(7) });
            }
            else
            {
                Response.Cookies.Append(cookieKey, "1", new CookieOptions { Expires = DateTime.Now.AddDays(7) });
            }

            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            var cartItems = new List<CartItem>();
            foreach (var cookie in Request.Cookies)
            {
                if (cookie.Key.StartsWith("article"))
                {
                    int articleId = int.Parse(cookie.Key.Replace("article", ""));
                    int quantity = int.Parse(cookie.Value);
                    var article = _context.Articles.FirstOrDefault(a => a.Id == articleId);
                    if (article != null)
                    {
                        cartItems.Add(new CartItem(article, quantity));
                    }
                }
            }

            cartItems.Sort((c1, c2) => string.Compare(c1.Article.Name, c2.Article.Name, StringComparison.Ordinal));

            return View(cartItems);
        }

        public IActionResult IncreaseQuantity(int articleId)
        {
            string cookieKey = $"article{articleId}";
            if (Request.Cookies.ContainsKey(cookieKey))
            {
                int currentQuantity = int.Parse(Request.Cookies[cookieKey]!);
                Response.Cookies.Append(cookieKey, (currentQuantity + 1).ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(7) });
            }

            return RedirectToAction("Cart");
        }

        public IActionResult DecreaseQuantity(int articleId)
        {
            string cookieKey = $"article{articleId}";
            if (Request.Cookies.ContainsKey(cookieKey))
            {
                int currentQuantity = int.Parse(Request.Cookies[cookieKey]!);
                if (currentQuantity > 1)
                {
                    Response.Cookies.Append(cookieKey, (currentQuantity - 1).ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(7) });
                }
                else
                {
                    Response.Cookies.Delete(cookieKey);
                }
            }

            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int articleId)
        {
            string cookieKey = $"article{articleId}";
            if (Request.Cookies.ContainsKey(cookieKey))
            {
                Response.Cookies.Delete(cookieKey);
            }

            return RedirectToAction("Cart");
        }

        [Authorize]
        public IActionResult Order()
        {
            var cartItems = new List<OrderItem>();
            decimal totalCost = 0;

            foreach (var cookie in Request.Cookies)
            {
                if (cookie.Key.StartsWith("article"))
                {
                    if (int.TryParse(cookie.Key.AsSpan("article".Length), out int articleId) &&
                        int.TryParse(cookie.Value, out int quantity))
                    {
                        var article = _context.Articles.Include(a => a.Category).FirstOrDefault(a => a.Id == articleId);
                        if (article != null)
                        {
                            cartItems.Add(new OrderItem(article, quantity));
                            totalCost += article.Price * quantity;
                        }
                    }
                }
            }

            var model = new OrderModel
            {
                CartItems = cartItems,
                TotalCost = totalCost
            };

            return View(model);
        }

        private IEnumerable<OrderItem> GetOrderItems()
        {
            var cartItems = new List<OrderItem>();
            foreach (var cookie in Request.Cookies)
            {
                if (cookie.Key.StartsWith("article"))
                {
                    if (int.TryParse(cookie.Key.AsSpan("article".Length), out int articleId) &&
                        int.TryParse(cookie.Value, out int quantity))
                    {
                        var article = _context.Articles.Include(a => a.Category).FirstOrDefault(a => a.Id == articleId);
                        if (article != null)
                        {
                            cartItems.Add(new OrderItem(article, quantity));
                        }
                    }
                }
            }
            return cartItems;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(string fullName, string address, string paymentMethod)
        {
            var orderItems = GetOrderItems();

            foreach (var cookie in Request.Cookies.Where(c => c.Key.StartsWith("article")))
            {
                Response.Cookies.Delete(cookie.Key);
            }

            var model = new ConfirmationViewModel
            {
                FullName = fullName,
                Address = address,
                PaymentMethod = paymentMethod
            };

            _context.OrderItems.AddRange(orderItems);

            _context.Orders.Add(new Order
            {
                FullName = fullName,
                Address = address,
                PaymentMethod = paymentMethod,
                TotalCost = orderItems.Sum(c => c.Quantity * c.Article.Price),
                OrderItems = orderItems.ToList()
            });

            await _context.SaveChangesAsync();

            return View("OrderConfirmed", model);
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> GetArticlesForPage(int page, int pageSize = 16, int? categoryId = null)
        {
            var articles = await _context.Articles
                .Where(a => categoryId == null || a.CategoryId == categoryId)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(a => new ArticleDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    CategoryId = a.CategoryId,
                    ExpirationDate = a.ExpirationDate,
                    Quantity = a.Quantity,
                    CategoryName = a.Category.Name,
                    ImagePath = ImageHelper.GetImagePath(a.ImageName)
                })
                .ToListAsync();

            return articles;
        }

        [HttpGet]
        public async Task<IActionResult> LoadArticles(int page, int pageSize = 16, int? categoryId = null)
        {
            var articles = await GetArticlesForPage(page, pageSize, categoryId);

            if (!articles.Any())
            {
                return NoContent();
            }

            return Json(articles);
        }
    }

    public class ArticleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
    }
}
