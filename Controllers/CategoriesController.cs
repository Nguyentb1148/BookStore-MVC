using BulkyBook1Web.Data;
using BulkyBook1Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook1Web.Controllers;

public class CategoriesController : Controller
{
    private readonly ApplicationDBContext _db;

    public CategoriesController(ApplicationDBContext db)
    {
        _db = db;
    }

    // GET all category from DB
    public IActionResult Index()
    {
        var categoryFromDb = _db.Categories.ToList();
        return View(categoryFromDb);
    }
    
    //GET
    public IActionResult CreateCategory()
    {
        
        return View();
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateCategory(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj); //not add data in database yet
            _db.SaveChanges(); // SaveChanges will save date we input in the form to database
            return RedirectToAction("Index");
            //User RedirectToAction when we turn back to Index view when we submit in Create category view
            // if we want to return other view, use ("Index","other controller")
        }

        return View(obj);
    }


}
