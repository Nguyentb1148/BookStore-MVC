using BulkyBook1Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook1Web.Controllers;

public class CategoriesController : Controller
{
    private readonly ApplicationDBContext _db;

    public CategoriesController(ApplicationDBContext db)
    {
        _db = db;
    }
    
    // GET all category from database
    public IActionResult Index()
    {
        var categoryFromDb = _db.Categories.ToList();
        return View(categoryFromDb);
    }
}