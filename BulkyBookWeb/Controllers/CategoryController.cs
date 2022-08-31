using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        // since we are adding dependency injector, we need not create an object to access db here, just use it.

        //We need to tell our App that we need an implementation of this ApplicationDBContext where connection to DB is already made. Use ctor and double tab.
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();  Rather than using var, this is better? need to call models and remove .ToList() from end.
            IEnumerable<Category> objCategoryList = _db.Categories;  // No Select statement, no dt to list conversion in sight!
            return View(objCategoryList);
        }
        //To add view, you can do manually or just right click on Index() (which is an action) here and say add view and add a razor view.
        //Don't add empty razor view, add 2nd one. Keep page name same as action name, and Keep Template empty for now. Don't create partial view, use layout page.

        //GET
        public IActionResult Create()
        {
            return View();  //we dont need to pass anything from here, can pass from view directly
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]  //Nice!     Helps prevent Cross Site Request Forgery attack.
        //What is does is in any form, it will inject a key and it will be validated at the step, that key must be valid to prevent cross site request forgery.
        // https://www.youtube.com/watch?v=3IQ3wgpjizc check out in detail.
        public IActionResult Create(Category obj)   //This for getting values from Create button in create category
        {
            if (obj.Name == obj.DisplayOrder.ToString())    //Custom error validations; also server side
            {
                //ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");    // will show error on top.
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");     // will add the error under name textbox as well
            }
            if (ModelState.IsValid) //Server side validations   If it is not valid, we can check error count and which properties are not valid in values -> result view.
            {
                _db.Categories.Add(obj);    //So simple to add it to the DB
                _db.SaveChanges();          //It will be pushed to DB here.
                return RedirectToAction("Index");   //Can add action from another controller like ("Index","Home")
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? @id)     //To get existing data in textboxes
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);   // _db.Categories will get all values from db
            //var CategoeyFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id); // Also find First and check difference in exceptions 
            //var CategoeyFromDbSingle= _db.Categories.SingleOrDefault(u => u.Id == id); // Also find Single and check difference in exceptions 

           if(CategoryFromDb == null) { return NotFound(); }

            return View(CategoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]  
        
        public IActionResult Edit(Category obj)   //This for getting values from Create button in create category
        {
            if (obj.Name == obj.DisplayOrder.ToString())    //Custom error validations; also server side
            {
                //ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");    // will show error on top.
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");     // will add the error under name textbox as well
            }
            if (ModelState.IsValid) //Server side validations   If it is not valid, we can check error count and which properties are not valid in values -> result view.
            {
                _db.Categories.Add(obj);    //So simple to add it to the DB
                _db.SaveChanges();          //It will be pushed to DB here.
                return RedirectToAction("Index");   //Can add action from another controller like ("Index","Home")
            }
            return View(obj);
        }

    }
}
