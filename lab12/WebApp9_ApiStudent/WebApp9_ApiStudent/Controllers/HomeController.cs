using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp9_ApiStudent.Models;

namespace WebApp9_ApiStudent.Controllers
{
    public class HomeController : Controller
    {
        private IRepository Repository { get; set; }

        public HomeController(IRepository repo) => Repository = repo;

        public ViewResult Index() => View(Repository.Students);

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            Repository.AddStudent(student);
            return RedirectToAction("Index");
        }
    }
}
