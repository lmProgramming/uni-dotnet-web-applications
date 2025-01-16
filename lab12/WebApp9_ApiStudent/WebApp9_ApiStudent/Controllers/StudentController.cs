using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9_ApiStudent.Models;

namespace WebApp9_ApiStudent.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository repository;
        // GET: StudentController

        public StudentController(IRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
            return View(repository.Students.OrderBy(s=>s.Id));
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(repository[id]);
        }
        public ActionResult Next(int id)
        {
            Student? stud = repository.GetNextStudent(id);
            if(stud==null)
                return RedirectToAction(nameof(Details), new { id });
            else
                return RedirectToAction(nameof(Details), new { id = stud.Id });
        }
        public ActionResult Previous(int id)
        {
            Student? stud = repository.GetPreviousStudent(id);
            if (stud == null)
                return RedirectToAction(nameof(Details), new { id });
            else
                return RedirectToAction(nameof(Details), new { id = stud.Id });
        }

    }
}
