using App.Domain;

namespace App.Services
{
    public interface ICollegesService
    {
        Task<IEnumerable<College>> GetAllAsync();
        Task<College> GetByIdAsync(int CollegeId);
        Task AddAsync(College college);
        College Update (int  CollegeId, College newCollege);
        void Delete (int CollegeId);
    }
}
