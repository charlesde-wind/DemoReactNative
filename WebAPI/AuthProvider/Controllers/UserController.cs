using AuthProvider.Data;
using AuthProvider.Models.DTO;
using AuthProvider.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AuthProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthProviderRepository _authProviderRepository;
        private readonly IUserService _userService;

        public UserController(IAuthProviderRepository authProviderRepository, IUserService userService)
        {
            _authProviderRepository = authProviderRepository;
            _userService = userService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserDTO registerUser, CancellationToken cancellationToken) 
        {
            var identityUserResult = await _userService.CreateUser(registerUser, cancellationToken);
            if (!identityUserResult.IsValid || identityUserResult.ResultObject == null)
            {
                return BadRequest(identityUserResult.ErrorMessage);
            }

            var jwtToken = _userService.CreateJWTToken(identityUserResult.ResultObject, cancellationToken);

            return Ok(jwtToken);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult> Login(LoginUserDTO loginUser, CancellationToken cancellationToken) 
        {
            var identityUserResult = await _userService.Login(loginUser, cancellationToken);
            if (!identityUserResult.IsValid || identityUserResult.ResultObject == null)
            {
                return BadRequest(identityUserResult.ErrorMessage);
            }

            var jwtToken = _userService.CreateJWTToken(identityUserResult.ResultObject, cancellationToken);

            return Ok(jwtToken);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("ffsff");
        }
    }
}
