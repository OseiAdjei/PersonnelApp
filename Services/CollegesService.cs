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
        public void Add(College college)
        {
            throw new NotImplementedException();
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

        public College GetById(int id)
        {
            throw new NotImplementedException();
        }

        public College Update(int id, College newCollege)
        {
            throw new NotImplementedException();
        }
    }
}
