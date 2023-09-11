using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsanddishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsanddishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;

        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> Chefs = _context.Chefs.Include(d => d.AllDishes).ToList();
        
        return View("Index", Chefs);
    }

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        List<Dish> Dishes = _context.Dishes.Include(d => d.OneChef).ToList();
        return View("Dishes", Dishes);
    }

    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {

        return View();
    }

    [HttpPost("create/chef")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(!ModelState.IsValid)
        {
            return View("NewChef");
        }
        _context.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("Index", "Dish");
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        List<Chef> Chefs = _context.Chefs.ToList();
        ViewBag.MyChef = Chefs;
        return View("NewDish");
    }

    [HttpPost("create/dish")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(!ModelState.IsValid)
        {
            List<Chef> Chefs = _context.Chefs.ToList();
            ViewBag.MyChef = Chefs;
            return View("NewDish");
        }
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index", "Dish");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
