using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorCookies.Data;
using RazorCookies.Models;

namespace RazorCookies.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly ArticleDbContext _context;

        public IndexModel(ArticleDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;
        public SelectList Categories { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        public async Task OnGetAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            if (CategoryId is null)
            {
                ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            }
            else
            {
                ViewData["Categories"] = new SelectList(categories, "Id", "Name", CategoryId);
            }

            IQueryable<Article> articleQuery = _context.Articles.Include(a => a.Category);

            if (CategoryId.HasValue)
            {
                articleQuery = articleQuery.Where(a => a.CategoryId == CategoryId.Value);
            }

            Article = await articleQuery.ToListAsync();
        }
    }
}
