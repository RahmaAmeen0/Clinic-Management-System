using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; } = string.Empty;
        [StringLength(500)]
        public string? Description { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
    }
}
