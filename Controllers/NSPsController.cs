using App.Domain;
using App.Services;
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
        public async Task<IActionResult> Details_Personnel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nsp = await _context.Nsp.FindAsync(id);
            if (nsp == null)
            {
                return NotFound();
            }

            return View(nsp);
        }

        public async Task<IActionResult> Edit_Personnel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nsp = await _context.Nsp.FindAsync(id);
            if (nsp == null)
            {
                return NotFound();
            }
            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            var departments = await _context.Department.ToListAsync();
            ViewData["Departments"] = departments;

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = faculties;

            return View(nsp);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit_Personnel(int id, [Bind("NspId,NspName,NspNumber,NspPicUrl,NspEmail,NspPhone,NspBio")]Nsp updatedNsp)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedNsp);
            }
            var existNsp = await _context.Nsp.FindAsync(id);
            if (existNsp == null)
            {
                return NotFound();
            }
            existNsp.NspName = updatedNsp.NspName;
            existNsp.NspNumber = updatedNsp.NspNumber;
            existNsp.NspBio = updatedNsp.NspBio;
            existNsp.NspPhone = updatedNsp.NspPhone;
            existNsp.NspPicUrl = updatedNsp.NspPicUrl;
            existNsp.NspEmail = updatedNsp.NspEmail;

            _context.Nsp.Update(existNsp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete_Personnel (int? id)
        { 
            if (id == null)
            {
                return NotFound();
            }
            var nsp = await _context.Nsp.FindAsync(id);
            if (nsp == null)
            {
                return NotFound();
            }
            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            var departments = await _context.Department.ToListAsync();
            ViewData["Departments"] = departments;

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = faculties;

            return View(nsp);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            var departments = await _context.Department.ToListAsync();
            ViewData["Departments"] = departments;

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = faculties;

            var nsp = await _context.Nsp.FindAsync(id);
            if (nsp==null)
            {
                return NotFound();
            }

            _context.Nsp.Remove(nsp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
