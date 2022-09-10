using Microsoft.AspNetCore.Mvc;

namespace BulkyBook1Web.Controllers;

public class UsersController : Controller
{
    // GET
    public IActionResult IndexUsers()
    {
        return View();
    }
}