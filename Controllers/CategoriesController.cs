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
        if (obj.Name==obj.DisplayOder.ToString())
        {
            // Can use key"name" to get Errormessage under the field
            ModelState.AddModelError("CustomError","The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj); //not add data in database yet
            _db.SaveChanges(); // SaveChanges will save date we input in the form to database
            TempData["Success"] = "Category created  successfully";// Make notification
            return RedirectToAction("Index");
            //User RedirectToAction when we turn back to Index view when we submit in Create category view
            // if we want to return other view, use ("Index","other controller")
        }

        return View(obj);
    }
    //GET
    public IActionResult EditCategory(int? id)
    {
        if (id == null||id==0)
        {
            return NotFound();
        }
        var categoryFormDb = _db.Categories.Find(id);
        // var CategoryFormDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        // var CategoryFormDbSingle = _db.Categories.SingleOrDefault(u=>u.Id==id);
        if (categoryFormDb==null)
        {
            return NotFound();
        }
        return View(categoryFormDb);
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditCategory(Category obj)
    {
        if (obj.Name==obj.DisplayOder.ToString())
        {
            ModelState.AddModelError("CustomError","The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges(); 
            TempData["Success"] = "Category updated  successfully";

            return RedirectToAction("Index");
        }
        return View(obj);
    }
    
    public IActionResult DeleteCategory(int? id)
    {
        if (id == null||id==0)
        {
            return NotFound();
        }
        var categoryFormDb = _db.Categories.Find(id);
       
        if (categoryFormDb==null)
        {
            return NotFound();
        }
        return View(categoryFormDb);
    }
    
    //POST
    [HttpPost,ActionName("Delete")]//Change action name(DeleteCategoryPOST -> Delete)
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCategoryPOST(int? id)
    {
        var obj = _db.Categories.Find(id);
        if (obj==null)
        {
            return NotFound();
        }
        _db.Categories.Remove(obj);
        _db.SaveChanges(); 
        TempData["Success"] = "Category deleted  successfully";
        return RedirectToAction("Index");
    }
}
