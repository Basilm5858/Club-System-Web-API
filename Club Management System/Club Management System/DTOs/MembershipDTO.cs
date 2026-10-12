using Club_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Club_Management_System.DTOs
{
    public class MembershipDTO
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
        [Range(100, 10000)]
        public decimal Price { get; set; }
        [Required]

        public string Status { get; set; } = string.Empty;
        public int MemberId { get; set; }
    }
    public class CreateMembershipDTO
    {
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]

        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(100, 10000)]
        public decimal Price { get; set; }
        [Required]

        public string Status { get; set; } = string.Empty;
        public int MemberId { get; set; }
    }
    public class UpdateMembershipDTO
    {
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]

        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(100, 10000)]
        public decimal Price { get; set; }
        [Required]

        public string Status { get; set; } = string.Empty;
        public int MemberId { get; set; }
    }
}
