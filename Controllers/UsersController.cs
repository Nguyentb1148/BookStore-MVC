using BulkyBook1Web.Data;
using BulkyBook1Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Graph;

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
    public IActionResult Register()
    {
        return View();
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User obj)
    {
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
    
    public IActionResult Login()
    {
        return View();
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null||id==0)
        {
            return NotFound();
        }
        var UserFormDb = _db.Users.Find(id);
        // var CategoryFormDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        // var CategoryFormDbSingle = _db.Categories.SingleOrDefault(u=>u.Id==id);
        if (UserFormDb==null)
        {
            return NotFound();
        }
        return View(UserFormDb);
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(User obj)
    {
        // if (obj.Name==obj.DisplayOder.ToString())
        // {
        //     ModelState.AddModelError("CustomError","The DisplayOrder cannot exactly match the Name");
        // }
        if (ModelState.IsValid)
        {
            _db.Users.Update(obj);
            _db.SaveChanges(); 
            TempData["Success"] = "Category updated  successfully";

            return RedirectToAction("Index");
        }
        return View(obj);
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null||id==0)
        {
            return NotFound();
        }
        var userFormDb = _db.Users.Find(id);
       
        if (userFormDb==null)
        {
            return NotFound();
        }
        return View(userFormDb);
    }
    
    //POST
    [HttpPost,ActionName("Delete")]//Change action name(DeleteCategoryPOST -> Delete)
    [ValidateAntiForgeryToken]
    public IActionResult DeleteUserPost(int? id)
    {
        var obj = _db.Users.Find(id);
        if (obj==null)
        {
            return NotFound();
        }
        _db.Users.Remove(obj);
        _db.SaveChanges(); 
        TempData["Success"] = "Category deleted  successfully";
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(string search)
    {
        ViewData["Getuserdata"] = search;
        var userQuery = from x in _db.Users select x;
        if (!string.IsNullOrEmpty(search))
        {
            userQuery = userQuery.Where(x=>x.name.Contains(search)||x.email.Contains(search));
        }

        return View(await userQuery.AsTracking().ToListAsync());
    }
}