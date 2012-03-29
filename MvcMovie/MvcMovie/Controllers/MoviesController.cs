using System.Data;
using System.Linq;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{ 
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _db = new MovieDbContext();

        //
        // GET: /Movies/

        public ViewResult Index()
        {
            return View(_db.Movies.ToList());
        }

        //
        // GET: /Movies/Details/5

        public ViewResult Details(int id)
        {
            Movie movie = _db.Movies.Find(id);
            return View(movie);
        }

        //
        // GET: /Movies/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Movies/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(movie);
        }
        
        //
        // GET: /Movies/Edit/5
 
        public ActionResult Edit(int id)
        {
            Movie movie = _db.Movies.Find(id);
            return View(movie);
        }

        //
        // POST: /Movies/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /Movies/Delete/5
 
        public ActionResult Delete(int id)
        {
            Movie movie = _db.Movies.Find(id);
            return View(movie);
        }

        //
        // POST: /Movies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Movie movie = _db.Movies.Find(id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}