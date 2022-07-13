using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using System.Collections.Generic;

namespace ExpenseTracker.Controllers
{
    public class ExpenditureTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenditureTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenditureType> objList = _db.ExpenditureTypes;
            return View(objList);

        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }

        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenditureType obj)
        {

            //Server side Validation
            if (ModelState.IsValid)
            {
                _db.ExpenditureTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(obj);
        }

        // GET-Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenditureTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.ExpenditureTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ExpenditureTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET-Update
        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenditureTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenditureType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenditureTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

