using Club_Management_System.Data;
using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Repos.Implementation
{
    public class BookingCustomRepo : GenericRepo<Booking>, IBooking
    {
        private readonly My_AppContext _context;

        public BookingCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<BookingDTO>> GetBookingpPaginationAsync(int pageno, int size, string? status, int? facilityId)
        {
            return await _context.Bookings
                .Include(x => x.Member)
                .Include(x => x.Facility)
                .Where(x => x.Status == status || x.FacilityId == facilityId)
                .OrderBy(x => x.Id)
                .Skip((pageno - 1) * size)
                .Take(size)
                .Select(x => new BookingDTO
                {
                    BookingDate = x.BookingDate,
                    Status = x.Status,
                    FacilityId = x.FacilityId,
                    MemberId = x.MemberId,
                    Id = x.Id,
                    StartTime = x.StartTime,
                    GroupSize = x.GroupSize,
                    EndTime = x.EndTime,
                }).ToListAsync();
        }

        public async Task<ICollection<ReportBookingDTO>> GetSummry()
        {
            return await _context.Bookings
                .Include(x => x.Facility)
                .GroupBy(x => x.Facility.Name)
                .Select(x => new ReportBookingDTO
                {
                    FacilityName = x.Key,
                    BookingCount = x.Count(),
                    Visitors = x.Sum(c => c.FacilityId), 
                }).ToListAsync();
        }
    }
}
