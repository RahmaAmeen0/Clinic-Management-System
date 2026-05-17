namespace ClinicManagementSystem.ViewModels
{
    public class DoctorScheduleViewModel
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        public List<ScheduleItemViewModel> Schedules { get; set; } = new();
    }
}
