using App.Domain;
namespace App.Services
{
    public interface IFacultyService
    {
        Task<Faculty> GetByIdAsync(int id);
    }
}
