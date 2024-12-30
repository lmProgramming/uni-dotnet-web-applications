using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp9_RazorPagesStudent.Data;
using WebApp9_RazorPagesStudent.Models;

namespace WebApp9_RazorPagesStudent.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly WebApp9_RazorPagesStudent.Data.StudentDbContext _context;

        public IndexModel(WebApp9_RazorPagesStudent.Data.StudentDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
