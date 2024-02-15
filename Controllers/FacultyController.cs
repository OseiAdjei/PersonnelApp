using App.Domain;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FacultyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IFacultyService _facultyService;

        public FacultyController(AppDbContext context, IFacultyService facultyService)
        {
            _facultyService = facultyService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allFaculties =await _context.Faculty.ToListAsync();
            return View(allFaculties);
        }
        [HttpGet]
        public async Task<IActionResult> NewFaculty() 
        {
            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> NewFaculty([Bind("FacultyLogoUrl,FacultyName,FacultyDean,FacultyDescription,FacultyEmail,CollegeId")] Faculty faculty)
        {
            try
            {
                var colleges = await _context.College.ToListAsync();
                ViewData["Colleges"] = colleges;

                if (!ModelState.IsValid)
                {
                    return View(faculty);
                }
                
                _context.Faculty.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "AN error occured whilst trying to retrieve the list of Colleges";
                return View(faculty);
            }
        }
    }
}
