namespace ClinicManagementSystem.ViewModels
{
    public class ScheduleItemViewModel
    {
        public int ScheduleId { get; set; }
        public string WorkDay { get; set; } = string.Empty;
        public string StartTimeFormatted { get; set; } = string.Empty;
        public string EndTimeFormatted { get; set; } = string.Empty;
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
    }
}
