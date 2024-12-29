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
    }
}
