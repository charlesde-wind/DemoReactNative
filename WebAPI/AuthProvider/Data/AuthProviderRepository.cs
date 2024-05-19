
using Microsoft.AspNetCore.Identity;

namespace AuthProvider.Data
{
    public class AuthProviderRepository : IAuthProviderRepository
    {
        public Task<IdentityUser?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}