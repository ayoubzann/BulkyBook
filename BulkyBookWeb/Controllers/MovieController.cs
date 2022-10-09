using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        //GET
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Movie> objMovieList = _db.Movies;
            return View(objMovieList);
        }

        //POST
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie obj)
        {
            if (obj.Title == obj.ReleaseDate.ToString())
            {
                ModelState.AddModelError("title", "The releasedate cannot be the same as the title.");
            }
            if (ModelState.IsValid)
            {
                _db.Movies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movieFromDb = _db.Movies.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.FirstOrDefault(c => c.Id == id);

            if (movieFromDb == null)
            {
                return NotFound();
            }
            return View(movieFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie obj)
        {
            if (obj.Title == obj.ReleaseDate.ToString())
            {
                ModelState.AddModelError("title", "The releasedate cannot be the same as the title.");
            }
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie updated successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movieFromDb = _db.Movies.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.FirstOrDefault(c => c.Id == id);

            if (movieFromDb == null)
            {
                return NotFound();
            }
            return View(movieFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.Movies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Movies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Movie deleted successfully";
            return RedirectToAction("Index");


        }











        //// GET: MovieController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: MovieController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: MovieController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: MovieController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: MovieController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: MovieController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: MovieController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: MovieController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
