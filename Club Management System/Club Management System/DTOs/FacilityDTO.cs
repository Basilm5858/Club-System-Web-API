using System.ComponentModel.DataAnnotations;

namespace Club_Management_System.DTOs
{
    public class FacilityDTO
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
    }
    public class CreateFacilityDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }
        [Required]
        [Range(50, 10000)]
        public decimal HourlyPrice { get; set; }
    }

    public class UpdateFacilityDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }
        [Required]
        [Range(50, 10000)]
        public decimal HourlyPrice { get; set; }
    }
}
