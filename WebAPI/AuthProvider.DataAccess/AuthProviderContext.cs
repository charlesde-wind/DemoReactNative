using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthProvider.DataAccess
{
    public class AuthProviderContext : IdentityDbContext
    {

        public AuthProviderContext(DbContextOptions<AuthProviderContext> dbContextOptions): base(dbContextOptions)
        {}

        protected override void OnModelCreating(ModelBuilder builder)=>base.OnModelCreating(builder);
    }
}