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
        public async Task<IActionResult> NewDepartment([Bind("DepartmentId,DepartmentName,DepartmentLogoUrl,DepartmentHod,DepartmentDescription," +
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
                ViewBag.ErrorMessage = "An error occured whilst trying to retrieve the list of Faculties";
                return View(department);
            }
        }
        public async Task<IActionResult> Details_Department(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        public async Task<IActionResult> Edit_Department(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = faculties;

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit_Department(int id, [Bind("DepartmentId,DepartmentName,DepartmentLogoUrl,DepartmentHod,DepartmentDescription,DepartmentEmail,FacultyId")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = faculties;

            return View(department);
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.DepartmentId == id);
        }
    }
}



