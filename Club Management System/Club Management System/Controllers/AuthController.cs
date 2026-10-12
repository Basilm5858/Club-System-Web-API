using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Club_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration configuration;
        public AuthController(IUnitOfWork unitOfWork,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var exi = await _unitOfWork.AuthRepoCustomRepo.GetUserByUserName(dto.UserName);
            if (exi != null)
            {
                return BadRequest("the user already exist");
            }

            var res = new User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                Role = dto.Role,
            };
            await _unitOfWork.AuthRepoCustomRepo.AddAsync(res);
            await _unitOfWork.SaveChangesAsync();

            return Ok(res);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _unitOfWork.AuthRepoCustomRepo.GetUserByUserName(dto.UserName);
            if(user == null)
            {
                return BadRequest("invalid username or password");
            }

            if (user.Password != dto.Password)
            {
                return BadRequest("invalid username or password");
            }

            var token = GenerateToken(user);
            return Ok(token);
        }

        private string GenerateToken(User user)
        {
            // Payload
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Signture
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Iss"],
                audience: configuration["JWT:Aud"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
