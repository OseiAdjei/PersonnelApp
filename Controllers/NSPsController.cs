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
    }
}
