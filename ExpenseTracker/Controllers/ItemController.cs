using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExpenseTracker.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
        //Always pathparameters id should be unique and if we want to 
        //use queryparameter irrespective of keyword we need to use ? in url
        public string GetName(int id,int id1)
        {
            return "Welcome " + id + "Name: " +id1;
        }

        //Get - Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj); 
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
