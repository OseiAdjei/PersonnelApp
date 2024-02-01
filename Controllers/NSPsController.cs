using App.Domain;
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
            var nsps = await _context.Nsp.ToListAsync();
            return View(nsps);
        }
        public IActionResult NewPersonnel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewPersonnel([Bind("NspName,NspNumber,NspPicUrl,NspBio,NspPhone,NspEmail")]Nsp nsp)
        {
            if(ModelState.IsValid)
            {
                return View(nsp);
            }
            _context.Add(nsp);
            return RedirectToAction(nameof(Index));
        }
    }
}
