using App.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allDepartments = await _context.Department.ToListAsync();
            return View(allDepartments);
        }
        [HttpGet]
        public async Task<IActionResult> NewDepartment()
        {
            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = faculties;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewDepartment([Bind("DepartmentName,DepartmnentLogoUrl,DepartmentHod,DepartmentDescription," +
            "DepartmentEmail,FacultyId")] Department department)
            {
            try
            {
                var faculties = await _context.Faculty.ToListAsync();
                ViewData["Faculties"] = faculties;

                if (!ModelState.IsValid)
                {
                    return View(department);
                }
                _context.Department.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction((nameof(Index)));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "AN error occured whilst trying to retrieve the list of Faculties";
                return View(department);
            }
        }
    }
}
