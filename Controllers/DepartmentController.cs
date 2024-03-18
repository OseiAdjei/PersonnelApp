
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
        public async Task<IActionResult> NewDepartment([Bind("DepartmentId,DepartmentName,DepartmentLogoUrl," +
            "DepartmentHod,DepartmentDescription," +
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
        public async Task<IActionResult> Edit_Department(int id, [Bind("DepartmentId,DepartmentName,DepartmentLogoUrl,DepartmentHod,DepartmentDescription,DepartmentEmail,FacultyId")] Department updatedDepartment)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedDepartment);
            }

            var existDepartment = await _context.Department.FindAsync(id);
            if (existDepartment == null)
            {
                return NotFound();
            }
            existDepartment.DepartmentName = updatedDepartment.DepartmentName;
            existDepartment.DepartmentHod = updatedDepartment.DepartmentHod;
            existDepartment.DepartmentDescription = updatedDepartment.DepartmentDescription;
            existDepartment.DepartmentEmail = updatedDepartment.DepartmentEmail;
            existDepartment.DepartmentLogoUrl = updatedDepartment.DepartmentLogoUrl;

            _context.Department.Update(existDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //public async Task<IActionResult> Delete_Department(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var faculties = await _context.Faculty.ToListAsync();
        //    ViewData["Faculties"] = faculties;

        //    var department = await _context.Department.FindAsync(id);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(department);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var faculties = await _context.Faculty.ToListAsync();
        //    ViewData["Faculties"] = faculties;

        //    var department = await _context.Department.FindAsync(id);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Department.Remove(department);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        }

    }



