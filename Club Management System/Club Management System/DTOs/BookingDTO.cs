using System.ComponentModel.DataAnnotations;

namespace Club_Management_System.DTOs
{
    public class BookingDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        [Range(1, 100)]
        public int GroupSize { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public int MemberId { get; set; }
        public int FacilityId { get; set; }
    }
    public class UpdateStatusBookingDTO()
    {
        [Required]
        public string Status { get; set; } = string.Empty;
    }
    public class ReportBookingDTO
    {
        public string FacilityName { get; set; } = string.Empty;
        public int Visitors { get; set; }
        public int BookingCount { get; set; }
    }
    public class CreateBookingDTO
    {
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        [Range(1, 100)]
        public int GroupSize { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public int MemberId { get; set; }
        public int FacilityId { get; set; }
    }

    public class UpdateBookingDTO
    {
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        [Range(1, 100)]
        public int GroupSize { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public int MemberId { get; set; }
        public int FacilityId { get; set; }
    }

}
