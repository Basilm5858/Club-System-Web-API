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
    public class BookingController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("Pagination")]
        public async Task<IActionResult> GetMemberByPagination(int pageno, int size, string? status, int? facilityId)
        {
            var res = await _unitOfWork.BookingCustomRepo.GetBookingpPaginationAsync(pageno, size, status, facilityId);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport()
        {
            var res = await _unitOfWork.BookingCustomRepo.GetSummry();
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _unitOfWork.BookingCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateBookingDTO dto)
        {
            var fis = _unitOfWork.FacilityCustomRepo.GetById(dto.FacilityId);
            if (fis == null)
            {
                return BadRequest("Facility not found");
            }
            var mem = _unitOfWork.MemberCustomRepo.GetById(dto.MemberId);
            if (mem == null)
            {
                return BadRequest("Member not found");
            }

            var booking = _mapper.Map<Booking>(dto);
            await _unitOfWork.BookingCustomRepo.AddAsync(booking);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateBookingDTO dto)
        {
            var fis = _unitOfWork.FacilityCustomRepo.GetById(dto.FacilityId);
            if (fis == null)
            {
                return BadRequest("Facility not found");
            }
            var mem = _unitOfWork.MemberCustomRepo.GetById(dto.MemberId);
            if (mem == null)
            {
                return BadRequest("Member not found");
            }

            var res = await _unitOfWork.BookingCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, res);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateStatusBookingDTO dto)
        {

            var res = await _unitOfWork.BookingCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            if(dto.Status != "Cancel")
            {
                return BadRequest("Status Must Be Cancel");
            }

            res.Status = dto.Status;

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _unitOfWork.BookingCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            _unitOfWork.BookingCustomRepo.Delete(res);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

    }
}
