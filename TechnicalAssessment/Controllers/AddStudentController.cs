using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalAssessment.Data;
using TechnicalAssessment.Models;
using TechnicalAssessment.Models.Entities;

namespace TechnicalAssessment.Controllers
{
    public class AddStudentController : Controller
    {
        private readonly ILogger<AddStudentController> _logger;
        private readonly AppDBContext _context;

        public AddStudentController(ILogger<AddStudentController> logger, AppDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Schools"] = GetSchools();
            return View();
        }

        private List<SelectListItem> GetSchools() {
            List<SelectListItem> schools = new List<SelectListItem>();
            var schoolList = _context.Schools.ToList();
            foreach (var school in schoolList)
            {
                schools.Add(new SelectListItem { Text = school.Name, Value = school.Id.ToString() });
            }
            return schools;
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.DateModified = DateTime.Now;
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewData["Schools"] = GetSchools();
            return View(student);
        }

        [HttpPost]
        public IActionResult AddSchool(School school)
        {
            if (ModelState.IsValid)
            {
                _context.Schools.Add(school);
                _context.SaveChanges();
                return RedirectToAction("Index", "AddStudent");
            }
            return View(school);
        }
    }


}