using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class FacultiesController : Controller
    {
        private readonly AppDbContext _context;

        public FacultiesController(AppDbContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allFaculties = await _context.Faculty.ToListAsync();
            return View(allFaculties);
        }
    }
}
