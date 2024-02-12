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

        //public async Task<IActionResult> CollegeDetails(int id)
        //{
        //    var collegeDetails = await _service.AddAsync(id);

        //    if (collegeDetails == null) return View("Empty");
        //    return View(collegeDetails);
        //}
    }
}
