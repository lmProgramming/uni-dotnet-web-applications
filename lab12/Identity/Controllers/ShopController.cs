using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorCookies.Data;
using RazorCookies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorCookies.Controllers
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
    }
}
