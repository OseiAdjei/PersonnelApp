using App.Domain;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CollegeController : Controller
    {
        public readonly ICollegesService _service;

        public CollegeController(ICollegesService service)
        {
                _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allColleges =await _service.GetAllAsync();
            return View(allColleges);
        }

        public IActionResult NewCollege()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewCollege([Bind("CollegeName,CollegeLogoUrl,CollegeDescription,CollegeProvost,CollegeEmail")]College college)
            {
            if (!ModelState.IsValid)
            {
                return View(college);
            }

            await _service.AddAsync (college);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var collegeDetails = await _service.GetByIdAsync(id);

            if (collegeDetails == null) return View("Empty");
            return View(collegeDetails);
        }

        // Editing the details of a College
        public async Task<IActionResult> Edit_College(int id)
        {
            var collegeDetails = await _service.GetByIdAsync (id);
            if (collegeDetails == null) return NotFound();
            return View(collegeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit_College(int id,[Bind("CollegeName,CollegeLogoUrl,CollegeDescription,CollegeProvost,CollegeEmail")] College updatedcollege)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedcollege);
            }
            var existCollege = await _service.GetByIdAsync(id);
            if (existCollege == null)
            {
                return NotFound();
            }
            existCollege.CollegeName = updatedcollege.CollegeName;
            existCollege.CollegeLogoUrl = updatedcollege.CollegeLogoUrl;
            existCollege.CollegeDescription = updatedcollege.CollegeDescription;
            existCollege.CollegeProvost = updatedcollege.CollegeProvost;
            existCollege.CollegeEmail = updatedcollege.CollegeEmail;

            await _service.UpdateAsync(id, existCollege);
            return RedirectToAction(nameof(Index));
        }
    }
}
