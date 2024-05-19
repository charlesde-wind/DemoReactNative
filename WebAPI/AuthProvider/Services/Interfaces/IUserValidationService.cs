using AuthProvider.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Shared.Models;

namespace AuthProvider.Services.Interfaces
{
    public interface IUserValidationService
    {
        ValidationResult<IdentityUser> ValidateLogin(LoginUserDTO login, CancellationToken token);
        ValidationResult<IdentityUser> ValidateRegisterUser(RegisterUserDTO registerUserDTO, CancellationToken token);
    }
}