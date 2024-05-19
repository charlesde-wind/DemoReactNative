using AuthProvider.Configuration;
using AuthProvider.Models.DTO;
using AuthProvider.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;
using Shared.Models.Constants;
using Shared.Models.Models.Validation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClaimTypes = Shared.Models.Constants.ClaimTypes;

namespace AuthProvider.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserValidationService _userValidationService;
        private readonly JWTOptions _jwtOptions;

        public UserService(UserManager<IdentityUser> userManager, 
            IUserValidationService userValidationService, 
            IOptions<JWTOptions> jwtOptions)
        {
            _userManager = userManager;
            _userValidationService = userValidationService;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<ValidationResult<IdentityUser>> CreateUser(RegisterUserDTO registerUser, CancellationToken token)
        {
            var validationResult = _userValidationService.ValidateRegisterUser(registerUser, token);
            if (!validationResult.IsValid)
            {
                return new ValidationResult<IdentityUser>(false, validationResult.ErrorMessage);
            }

            var identityUser = new IdentityUser()
            {
                Email = registerUser.Email,
                UserName = registerUser.Username
            };

            var result = await _userManager.CreateAsync(identityUser, registerUser.Password);
            if (!result.Succeeded)
            {
                return new ValidationResult<IdentityUser>(
                    false,
                    result.Errors.Select(x => x.Description).ToList());
            }

            identityUser = await _userManager.FindByEmailAsync(registerUser.Email);
            if (identityUser is null)
            {
                return new ValidationResult<IdentityUser>(
                    false,
                    FieldValidationRules.UserHasNotBeenCreated
                    );
            }
            return new ValidationResult<IdentityUser>(true, identityUser);
        }

        public async Task<ValidationResult<IdentityUser>> Login(LoginUserDTO loginUser, CancellationToken token)
        {
            var validationResult = _userValidationService.ValidateLogin(loginUser, token);
            if (!validationResult.IsValid)
            {
                return new ValidationResult<IdentityUser>(false, validationResult.ErrorMessage);
            }

            var identityUser = await _userManager.FindByEmailAsync(loginUser.Email);
            if (identityUser==null)
            {
                return new ValidationResult<IdentityUser>(
                    false,
                    ValidationErrorMessages.EmailAndPasswordDoNotExist);
            }

            var isExpectedPassword = await _userManager.CheckPasswordAsync(identityUser, loginUser.Password);
            if (!isExpectedPassword)
            {
                return new ValidationResult<IdentityUser>(
                    false,
                    ValidationErrorMessages.EmailAndPasswordDoNotExist);
            }

            return new ValidationResult<IdentityUser>(true, identityUser);
        }

        public string CreateJWTToken(IdentityUser identityUser, CancellationToken cancellationToken)
        {
            ValidateJwtOptions();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>() 
            {
                new (ClaimTypes.Name, identityUser.UserName!),
                new (ClaimTypes.EmailAddress, identityUser.Email!),
            };

            var securityToken = new JwtSecurityToken(
                claims: claims,
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                signingCredentials: signingCredentials,
                expires: DateTimeOffset.Now.AddMinutes(5).DateTime
                ); ;

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

            void ValidateJwtOptions()
            {
                var validatonResult = new ValidationResult(new JWTOptionsValidator().Validate(_jwtOptions));
                if (!validatonResult.IsValid)
                {
                    throw new ArgumentException("Jwt Options is invalid");
                }
            }
        }
    }
}
