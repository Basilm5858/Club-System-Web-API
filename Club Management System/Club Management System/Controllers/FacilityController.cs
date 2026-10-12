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
    public class FacilityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacilityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _unitOfWork.FacilityCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }
        [HttpGet("Sort")]
        public async Task<IActionResult> Sort()
        {
            var res = await _unitOfWork.FacilityCustomRepo.SortById();
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateFacilityDTO dto)
        {
            var facility = _mapper.Map<Facility>(dto);

            await _unitOfWork.FacilityCustomRepo.AddAsync(facility);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = facility.Id }, facility);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateFacilityDTO dto)
        {
            var res = await _unitOfWork.FacilityCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, res);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _unitOfWork.FacilityCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            _unitOfWork.FacilityCustomRepo.Delete(res);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
