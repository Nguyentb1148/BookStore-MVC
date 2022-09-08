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
        //  var categoryFromDb = _db.Categories.ToList();
        //  return View(categoryFromDb);
        return View();
    }
    //Create new Category
    // create nhu vay la dung roi nha


    // debuger ko nguyen phong ko biet xai app nay noi
    // [HttpPost]
    // public IActionResult CreateCategory(Category category)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _db.Categories.Add(category);
    //         _db.SaveChanges();
    //         return RedirectToAction(nameof(Index));
    //     }
    //
    //     return View(category);
    // }
    public IActionResult CreateCategory()
    {
        var categoryFromDb = _db.Categories.ToList();
        return View(categoryFromDb);
    }

}
