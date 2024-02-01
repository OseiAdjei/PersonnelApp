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
        public IActionResult NewDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewDepartment([Bind("DepartmentName,DepartmnentLogoUrl,DepartmentHod,DepartmentDescription,DepartmentEmail,")] Department department)
        {
            if(!ModelState.IsValid)
            {
                return View(department);
            }
            _context.Add(department);
            return RedirectToAction((nameof(Index)));
        }
    }
}
