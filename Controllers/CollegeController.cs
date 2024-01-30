using App.Domain;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CollegeController : Controller
    {
        private readonly ICollegesService _service;

        public CollegeController(ICollegesService service)
        {
                _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allColleges =await _service.GetAll();
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

            _service.Add(college);
            return RedirectToAction(nameof(Index));
        }
    }
}
