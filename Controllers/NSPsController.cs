using App.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Controllers
{
    public class NSPsController : Controller
    {
        private readonly AppDbContext _context;

        public NSPsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allnsps = await _context.Nsp.ToListAsync();
            return View(allnsps);
        }

        [HttpGet]
        public async Task<IActionResult> NewPersonnel()
        {
            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            var departments = await _context.Department.ToListAsync();
            ViewData["Departments"] = departments;

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = faculties;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewPersonnel([Bind("NspId,NspName,NspNumber,NspPicUrl,NspBio,NspPhone,NspEmail,CollegeId,FacultyId,DepartmentId")]Nsp nsp)
        {
            try
            {
                var colleges = await _context.College.ToListAsync();
                ViewData["Colleges"] = colleges;

                var departments = await _context.Department.ToListAsync();
                ViewData["Departments"] = departments;

                var faculties = await _context.Faculty.ToListAsync();
                ViewData["Faculties"] = faculties;

                if (!ModelState.IsValid)
            {
                return View(nsp);
            }
            _context.Nsp.Add(nsp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
