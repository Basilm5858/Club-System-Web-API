using System.ComponentModel.DataAnnotations;

namespace Club_Management_System.Models
{
    public class Booking
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
        public Member Member { get; set; }
        public Facility Facility { get; set; }
    }
}
