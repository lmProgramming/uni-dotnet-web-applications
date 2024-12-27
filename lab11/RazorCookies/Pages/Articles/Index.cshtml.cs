using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Data;
using EntityFramework.Models;

namespace RazorCookies.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly EntityFramework.Data.ArticleDbContext _context;

        public IndexModel(EntityFramework.Data.ArticleDbContext context)
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
