using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static RazorCookies.Utilities.ImageHelper;
using RazorCookies.Data;
using RazorCookies.Models;

namespace RazorCookies.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly ArticleDbContext _context;

        public CreateModel(ArticleDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Article.Category = (await _context.Categories.FindAsync(Article.CategoryId))!;

            ModelState.Clear();
            TryValidateModel(Article);

            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
                return Page();
            }

            SaveArticleImage(Article, ImageFile);

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
