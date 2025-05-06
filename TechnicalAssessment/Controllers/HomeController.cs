using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Data;
using TechnicalAssessment.Models;
using TechnicalAssessment.Models.Entities;

namespace TechnicalAssessment.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDBContext _context;

    public List<Student> Students = new List<Student>();
    public List<School> Schools = new List<School>();

    public HomeController(ILogger<HomeController> logger, AppDBContext context)
    {
        _context = context;
        _logger = logger;
        Students = _context.Students.ToList();
        Schools = _context.Schools.ToList();
    }



    public IActionResult Index()
    {
        ViewData["Schools"] = Schools;
        return View(Students);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
