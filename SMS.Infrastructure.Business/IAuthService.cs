using AutoMapper;
using eSealClientSample.Domain.Patterns.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Business
{
    public interface IAuthService
    {
        public Task<AuthModel> RegesterUsers(RegisterUserModel registerusermodel);
        public Task<AuthModel> LoginUser(LoginModel registerusermodel);
    }

    public class AuthService:IAuthService
    {
        readonly UserManager<IdentityUser> UserManager;
        public IMapper _mapper;
        readonly JWTConfigurationModel Jwt;
        public IUnitOfWork _unitOfWork;
        public RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<IdentityUser> userManager,
        IOptions<JWTConfigurationModel> jwt,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        RoleManager<IdentityRole> roleManager
        )
        {
            Jwt = jwt.Value;
            UserManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }

        public async Task<AuthModel> RegesterUsers(RegisterUserModel registerusermodel)
        {
            try
            {
                if(await UserManager.FindByEmailAsync(registerusermodel.Email) is not null)
                {
                    return new AuthModel { Message = "User Already Exsits", IsAuthenticated = false };
                }

                var User = new IdentityUser {Email = registerusermodel.Email, UserName = registerusermodel.Name};
                var result = await UserManager.CreateAsync(User, registerusermodel.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        errors += $"{error.Description},";
                    }
                    return new AuthModel { Message = errors };
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key));
                var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                issuer: Jwt.Issuer,
                    audience: Jwt.Audience,
                    //claims: claims,
                    expires: DateTime.UtcNow.AddDays(Jwt.DurationInDays),
                    signingCredentials: signInCredentials
                    );

                return new AuthModel
                {
                    Username = registerusermodel.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    TokenExpirationDate = token.ValidTo,
                    Message = "Registration Successed",
                    IsAuthenticated = true
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AuthModel> LoginUser(LoginModel Loginusermodel)
        {
            try
            {
                IdentityUser User = await UserManager.FindByEmailAsync(Loginusermodel.Email);
                if (User is null || !(await UserManager.CheckPasswordAsync(User, Loginusermodel.Password)))
                {
                    return new AuthModel { Message = "Wrong Credentials recived", IsAuthenticated = false };
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key));
                var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                issuer: Jwt.Issuer,
                    audience: Jwt.Audience,
                    expires: DateTime.UtcNow.AddDays(Jwt.DurationInDays),
                    signingCredentials: signInCredentials
                    );

                return new AuthModel
                {
                    Username = User.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    TokenExpirationDate = token.ValidTo,
                    Message = "Login Successed",
                    IsAuthenticated = true
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
