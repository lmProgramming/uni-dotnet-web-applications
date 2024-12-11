using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAsp8RazorDemo.Data;
using WebAsp8RazorDemo.Models.ViewModels;

namespace RazorViewsServices.Controllers
{
    public class ArticleController(IArticleContext articleContext) : Controller
    {
        private IArticleContext _articleContext = articleContext;

        // GET: ArticleController
        public ActionResult Index()
        {
            return View(_articleContext.GetArticles());
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            return View(_articleContext.GetArticle(id));
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleViewModel article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _articleContext.AddArticle(article);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_articleContext.GetArticle(id));
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleViewModel articleViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    articleViewModel.Id = id; // added
                    _articleContext.UpdateArticle(articleViewModel); //added
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articleContext.GetArticle(id));
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticleViewModel articleViewModel)
        {
            try
            {
                _articleContext.RemoveArticle(id); // zmiana
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
