using System.Security.Claims;
using AutoMapper;
using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Club_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        }

    }
}
