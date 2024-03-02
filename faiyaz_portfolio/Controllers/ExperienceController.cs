using faiyaz_portfolio.Data;
using faiyaz_portfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace faiyaz_portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private ApplicationDbContext _db;
        public ExperienceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Experience> objCategoryList = _db.Experiences.ToList();
            return View(objCategoryList);
            
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Experience obj)
        {
            if (ModelState.IsValid)
            {
                _db.Experiences.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Experience categoryFromDb = _db.Experiences.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Experience obj)
        {
            if (ModelState.IsValid)
            {
                _db.Experiences.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Experience categoryFromDb = _db.Experiences.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Experience categoryFromDb = _db.Experiences.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _db.Experiences.Remove(categoryFromDb);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
