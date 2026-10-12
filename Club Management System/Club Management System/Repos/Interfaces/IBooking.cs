using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Implementation;

namespace Club_Management_System.Repos.Interfaces
{
    public interface IBooking : IGenericRepo<Booking>
    {
        Task<ICollection<BookingDTO>> GetBookingpPaginationAsync(int pageno, int size, string? status, int? facilityId);
        Task<ICollection<ReportBookingDTO>> GetSummry();
    }
}
