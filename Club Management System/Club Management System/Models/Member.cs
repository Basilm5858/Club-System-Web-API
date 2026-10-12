using System.ComponentModel.DataAnnotations;

namespace Club_Management_System.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        public Membership Membership { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();   
    }
}