using App.Domain;

namespace App.Services
{
    public interface IFacultiesService
    {
        Task<IEnumerable<Faculty>> GetAll();

        Faculty GetById(int id);
        void Add(Faculty faculty);
        College Update(int id, Faculty newFaculty);
        void Delete(int id);
    }
}
