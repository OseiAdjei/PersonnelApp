using App.Domain;

namespace App.Services
{
    public interface INSPService
    {
        Task<Nsp> GetByIdAsync(int NspId);

    }
}
