using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Club_Management_System.Models
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]

        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(100,10000)]
        public decimal Price { get; set; }
        [Required]

        public string Status { get; set; } = string.Empty;
        public Member Member { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();


    }
}
