using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAsp8RazorDemo.Data;
using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Controllers
{
    public class StudentController : Controller
    {
        private IStudentContext _studentContext;

        public StudentController(IStudentContext studentContext)
        {
            this._studentContext = studentContext;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(_studentContext.GetStudents());// addded parameter
        }

        public ActionResult AnotherIndex() // new action added manually
        {
            return View(_studentContext.GetStudents());
        }

        //[Route("newDetails/{id}", Name ="newDetailsRoute")]
        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_studentContext.GetStudent(id)); // added parameter
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleViewModel student) // change of parameter, data binding
        {
            try
            {
                if (ModelState.IsValid)                // added
                    _studentContext.AddStudent(student);  // added
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_studentContext.GetStudent(id)); // added parameter
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleViewModel studentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentViewModel.Id = id; // added
                    _studentContext.UpdateStudent(studentViewModel); //added
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_studentContext.GetStudent(id)); // zmiana
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticleViewModel studentViewModel)
        {
            try
            {
                _studentContext.RemoveStudent(id); // zmiana
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
