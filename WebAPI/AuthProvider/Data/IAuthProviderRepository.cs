using Microsoft.AspNetCore.Identity;

namespace AuthProvider.Data
{
    public interface IAuthProviderRepository
    {
        Task<IdentityUser?> GetById(int id);

    }
}