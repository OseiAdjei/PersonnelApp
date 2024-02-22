using App.Domain;
using App.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            var allFaculties = await _context.Faculty.ToListAsync();
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
                ViewBag.ErrorMessage = "There was an error retrieving the list of colleges";
                return View(faculty);
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty
                .Include(f => f.College) // Include related college
                .FirstOrDefaultAsync(m => m.FacultyId == id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }
        public async Task<IActionResult> Edit_Faculty(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            var faculty = await _context.Faculty
                .Include(f => f.College) // Include related college
                .FirstOrDefaultAsync(m => m.FacultyId == id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit_Faculty(int id, [Bind("FacultyLogoUrl,FacultyName,FacultyDean,FacultyDescription,FacultyEmail,CollegeId")] Faculty faculty)
        {
            if (id != faculty.FacultyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.FacultyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            return View(faculty);
        }

        private bool FacultyExists(int id)
        {
            return _context.Faculty.Any(e => e.FacultyId == id);
        }

        public async Task<IActionResult> Delete_Faculty(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faculty = await _context.Faculty.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            var colleges = await _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;
            return View(faculty);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var colleges = _context.College.ToListAsync();
            ViewData["Colleges"] = colleges;

            var faculty = await _context.Faculty.FindAsync(id);
            if (faculty==null)
            {
                return NotFound();
            }
            
            _context.Faculty.Remove(faculty);
            await _context.SaveChangesAsync();
            return View(faculty);
        }
    }
}
