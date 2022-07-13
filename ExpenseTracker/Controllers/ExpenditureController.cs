using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenditureController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expenditure> objList = _db.Expenditures;
            foreach (var obj in objList)
            {
                obj.ExpenditureType = _db.ExpenditureTypes.FirstOrDefault(u => u.Id == obj.ExpenditureTypeId);
            }
            return View(objList);

        }

        //Get - Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenditureTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });

            ViewBag.TypeDropDown = TypeDropDown;

            return View();
        }

        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expenditure obj)
        {

            //Server side Validation
            if (ModelState.IsValid)
            {
                //obj.ExpenditureTypeId = 1;
                _db.Expenditures.Add(obj);
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
            var obj = _db.Expenditures.Find(Id);
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
            var obj = _db.Expenditures.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenditures.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET-Update
        [HttpGet]
        public IActionResult Update(int? Id)
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenditureTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()

            });

            ViewBag.TypeDropDown = TypeDropDown;

            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenditures.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expenditure obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenditures.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

