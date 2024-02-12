using App.Domain;

namespace App.Services
{
    public interface INSPService
    {
        Task<IEnumerable<Nsp>> GetAllAsync();
        Task<Nsp> GetByIdAsync(int NspId);
        Task AddAsync(Nsp nsp);

    }
}
