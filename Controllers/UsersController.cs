using BulkyBook1Web.Data;
using BulkyBook1Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook1Web.Controllers;

public class UsersController : Controller
{
    private readonly ApplicationDBContext _db;

    public UsersController(ApplicationDBContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        var usersFromDb = _db.Users.ToList();
        return View(usersFromDb);    }
    //GET
    public IActionResult Login()
    {
        return View();
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(User obj)
    {
        // if (obj.Name==obj.DisplayOder.ToString())
        // {
        //     // Can use key"name" to get Errormessage under the field
        //     ModelState.AddModelError("CustomError","The DisplayOrder cannot exactly match the Name");
        // }
        if (ModelState.IsValid)
        {
            _db.Users.Add(obj); //not add data in database yet
            _db.SaveChanges(); // SaveChanges will save date we input in the form to database
            TempData["Success"] = "User created  successfully";// Make notification
            return RedirectToAction("Index");
            //User RedirectToAction when we turn back to Index view when we submit in Create category view
            // if we want to return other view, use ("Index","other controller")
        }
        return View(obj);
    }
    
}