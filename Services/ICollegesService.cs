using App.Domain;

namespace App.Services
{
    public interface ICollegesService
    {
        Task<IEnumerable<College>> GetAll();

        College GetById(int id);    
        void Add (College college);
        College Update (int  id, College newCollege);
        void Delete (int id);
    }
}
