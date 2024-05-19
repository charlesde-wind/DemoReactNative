using AuthProvider.Models.DTO;
using AuthProvider.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shared.Models;
using Shared.Models.Models.Validation;

namespace AuthProvider.Services
{
    public class UserValidationService : IUserValidationService
    {
        public ValidationResult<IdentityUser> ValidateRegisterUser(RegisterUserDTO registerUserDTO, CancellationToken token)
        {
            return new ValidationResult<IdentityUser>(new RegisterUserDTOValidator().Validate(registerUserDTO));
        }

        public ValidationResult<IdentityUser> ValidateLogin(LoginUserDTO login, CancellationToken token)
        {
            return new ValidationResult<IdentityUser>(new LoginUserDTOValidator().Validate(login));
        }
    }
}
