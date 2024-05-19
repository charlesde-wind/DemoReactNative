using AuthProvider.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Shared.Models;

namespace AuthProvider.Services.Interfaces
{
    public interface IUserService
    {
        string CreateJWTToken(IdentityUser identityUser, CancellationToken cancellationToken);
        Task<ValidationResult<IdentityUser>> CreateUser(RegisterUserDTO registerUser, CancellationToken token);
        Task<ValidationResult<IdentityUser>> Login(LoginUserDTO loginUser, CancellationToken token);
    }
}