using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Club_Management_System.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(100, 10000)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; } = string.Empty;
        [Required]
        [ForeignKey("Membership")]
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
