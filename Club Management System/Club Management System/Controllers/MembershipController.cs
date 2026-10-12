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
    public class MembershipController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MembershipController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetByActive()
        {
            var res = await _unitOfWork.MemberShipCustomRepo.GetMembersActiveAsync();
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _unitOfWork.MemberShipCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateMembershipDTO dto)
        {
            var member = _mapper.Map<Membership>(dto);

            await _unitOfWork.MemberShipCustomRepo.AddAsync(member);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update(int id)
        {
            var res = await _unitOfWork.MemberShipCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            if(res.Type == "Gold")
            {
                res.EndDate = DateTime.Now.AddYears(1);
            }
            if (res.Type == "Silver")
            {
                res.EndDate = DateTime.Now.AddMonths(3);
            }
            if (res.Type == "Basic")
            {
                res.EndDate = DateTime.Now.AddMonths(1);
            }

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _unitOfWork.MemberShipCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            _unitOfWork.MemberShipCustomRepo.Delete(res);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
