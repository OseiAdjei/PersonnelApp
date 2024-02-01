using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly AppDbContext _context;
        public FacultyService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Faculty faculty)
        {
            _context.Faculty.Add(faculty);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Faculty>> GetAll()
        {
            var result = await _context.Faculty.ToListAsync();
            return result;
        }

        public Faculty GetById(int id)
        {
            throw new NotImplementedException();
        }

        public College Update(int id, Faculty newFaculty)
        {
            throw new NotImplementedException();
        }
    }
}
