using eSealClientSample.Domain.Patterns.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Business;
using SMS.Infrastructure.Model;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IAuthService _authservice;
        public AuthController(IUnitOfWork unitofwork, IAuthService authservice)
        {
            _unitOfWork = unitofwork;
            _authservice = authservice;
        }

        [HttpPost]
        public async Task<IActionResult> RegiesterUser(RegisterUserModel registerUserModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    
            var result = await _authservice.RegesterUsers(registerUserModel);

            if(!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }

            return Ok(new { result.Token, result.TokenExpirationDate});
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginModel loginUsermodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authservice.LoginUser(loginUsermodel);

            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }

            return Ok(new { result.Token, result.TokenExpirationDate });
        }
    }
}
