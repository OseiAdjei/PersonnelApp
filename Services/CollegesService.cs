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

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
        public async Task<College> UpdateAsync(int id, College newCollege)
        {
            _context.Update(newCollege);
            await _context.SaveChangesAsync();
            return newCollege;
        }
    }
}
