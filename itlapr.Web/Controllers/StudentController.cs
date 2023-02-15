using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace itlapr.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudnetController
        public ActionResult Index()
        {
            List<Models.StudentModel> students = new List<Models.StudentModel>()
            {
                new Models.StudentModel()
                {
                     Email = "adfadf", FirstName ="adfad", LastName ="adfasdf", StudentId = 1
                },
                new Models.StudentModel()
                {
                    Email = "adfad", FirstName ="adsfsda", LastName ="afasd", StudentId = 2
                },
                new Models.StudentModel()
                {
                    Email = "afdf", FirstName ="adfdf", LastName ="adfasd", StudentId = 3
                },
                new Models.StudentModel()
                {
                  Email = "asdfdsf", FirstName ="afsadfsda", LastName ="asdfsda", StudentId = 4
                },

            };

            return View(students);
        }

        // GET: StudnetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudnetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudnetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudnetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudnetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudnetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudnetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
