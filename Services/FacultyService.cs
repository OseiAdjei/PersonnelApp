using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class FacultyService : IFacultyService

    {
        private readonly AppDbContext _context;
        public async Task<Faculty> GetByIdAsync(int id)
        {
            var result = await _context.Faculty.FirstOrDefaultAsync();
            return result;
        }
    }
}
