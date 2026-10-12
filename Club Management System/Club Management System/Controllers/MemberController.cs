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
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MemberController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("Pagination")]
        public async Task<IActionResult> GetMemberByPagination(int pageno, int size)
        {
            var res = await _unitOfWork.MemberCustomRepo.GetMemberspPaginationAsync(pageno, size);
            if(res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("Seach")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var res = await _unitOfWork.MemberCustomRepo.SearchMemberspAsyncByName(name);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _unitOfWork.MemberCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateMemberDTO dto)
        {
            var member = _mapper.Map<Member>(dto);

            await _unitOfWork.MemberCustomRepo.AddAsync(member);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpDelete("Update")]
        public async Task<IActionResult> Update(int id, UpdateMemberDTO dto)
        {
            var res = await _unitOfWork.MemberCustomRepo.GetById(id);
            if(res == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, res);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

    }
}
