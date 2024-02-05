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

        private readonly ICollegesService _service;
        public FacultyController(AppDbContext context, ICollegesService service)
        {
            _service = service;
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
            var colleges = await _service.GetAll();
            ViewData["Colleges"] = colleges;

            if(!ModelState.IsValid)
            {
                return View(faculty);
            }
            _context.Add(faculty);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
