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
    public class DetailsModel : PageModel
    {
        private readonly WebApp9_RazorPagesStudent.Data.StudentDbContext _context;

        public DetailsModel(WebApp9_RazorPagesStudent.Data.StudentDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);

            if (student is not null)
            {
                Student = student;

                return Page();
            }

            return NotFound();
        }
    }
}
