using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCookies.Data;
using RazorCookies.Models;

namespace RazorCookies.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly ArticleDbContext _context;

        public IndexModel(ArticleDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Article = await _context.Articles
                .Include(a => a.Category).ToListAsync();
        }
    }
}
