using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;

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

            var articles = _context.Articles.Include(a => a.Category).AsQueryable();

            if (categoryId.HasValue)
            {
                articles = articles.Where(a => a.CategoryId == categoryId.Value);
            }

            return View(await articles.ToListAsync());
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
            var cartItems = new List<(Article Article, int Quantity)>();
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
                            cartItems.Add((article, quantity));
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

        [HttpPost]
        public IActionResult ConfirmOrder(string FullName, string Address, string PaymentMethod)
        {
            foreach (var cookie in Request.Cookies.Where(c => c.Key.StartsWith("article")))
            {
                Response.Cookies.Delete(cookie.Key);
            }

            var model = new ConfirmationViewModel
            {
                FullName = FullName,
                Address = Address,
                PaymentMethod = PaymentMethod
            };

            return View("OrderConfirmed", model);
        }

        [HttpGet]
        public async Task<IActionResult> LoadArticles(int page = 1, int pageSize = 8)
        {
            var articles = await _context.Articles
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Price,
                    a.ImageName,
                    a.CategoryId
                })
                .ToListAsync();

            return Json(articles);
        }
    }
}
