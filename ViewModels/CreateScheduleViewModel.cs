using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.ViewModels
{
    public class CreateScheduleViewModel
    {
        public int? Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Please select a work day.")]
        public string WorkDay { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a start time.")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "Please select an end time.")]
        public TimeSpan EndTime { get; set; }
    }
}
