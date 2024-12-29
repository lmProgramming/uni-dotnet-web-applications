using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCookies.Data;
using RazorCookies.Models;

namespace RazorCookies.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ArticleDbContext _context;

        public DeleteModel(ArticleDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public int ArticleCount { get; set; } = 0;
        public string ArticlesListed { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }

            var articles = _context.Articles.Where(article => article.Category == category);

            ArticleCount = articles.Count();

            ArticlesListed = string.Join(',', articles.Select(article => article.Name));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);

            var articles = _context.Articles.Where(article => article.Category == category);
            foreach (var article in articles)
            {
                if (article.ImageName == null)
                {
                    continue;
                }
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", article.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            if (category != null)
            {
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
