using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Facility
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }
        [Required]
        [Range(50, 10000)]
        public decimal HourlyPrice { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
