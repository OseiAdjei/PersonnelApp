using App.Domain;

namespace App.Services
{
    public interface ICollegesService
    {
        Task<IEnumerable<College>> GetAllAsync();

        Task<College> GetByIdAsync(int id);    
        Task AddAsync(College college);
        College Update (int  id, College newCollege);
        void Delete (int id);
    }
}
