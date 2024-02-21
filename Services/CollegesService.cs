using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class CollegesService : ICollegesService
    {
        private readonly AppDbContext _context;
        public CollegesService(AppDbContext context)
        {
                _context = context;
        }
        public async Task AddAsync(College college)
        {
            await _context.College.AddAsync(college);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.College.FirstOrDefaultAsync(n=>n.CollegeId == id);
            _context.College.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<College>> GetAllAsync()
        {
            var result = await _context.College.ToListAsync();
            return result;
        }

        public async Task<College> GetByIdAsync(int id)
        {
            var result = await _context.College.FirstOrDefaultAsync(n => n.CollegeId == id);
            return result;
        }
        public async Task<College> UpdateAsync(int id, College updatedcollege)
        {
            _context.Update(updatedcollege);
            await _context.SaveChangesAsync();
            return updatedcollege;
        }
    }
}
