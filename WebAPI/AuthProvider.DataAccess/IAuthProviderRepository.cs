using Microsoft.AspNetCore.Identity;

namespace AuthProvider.DataAccess
{
    public interface IAuthProviderRepository
    {
        Task<IdentityUser?> GetById(int id);

    }
}