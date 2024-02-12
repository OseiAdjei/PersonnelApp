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

        public async Task<IEnumerable<College>> GetAll()
        {
            var result = await _context.College.ToListAsync();
            return result;
        }

        public Task<IEnumerable<College>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public College GetByIdA(int id)
        {
            throw new NotImplementedException();
        }

        public Task<College> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public College Update(int id, College newCollege)
        {
            throw new NotImplementedException();
        }
    }
}
