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

        public FacultyController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allFaculties =await _context.Faculty.ToListAsync();
            return View(allFaculties);
        }
        public IActionResult NewFaculty() 
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> NewFaculty([Bind("FacultyLogoUrl,FacultyName,FacultyDean,FacultyDescription,FacultyEmail")] Faculty faculty)
        {
            try
            {
                var colleges = await _context.College.ToListAsync();
                ViewData["Colleges"] = colleges;

                if (!ModelState.IsValid)
                {
                    return View(faculty);
                }
                _context.Add(faculty);

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
