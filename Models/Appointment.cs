namespace ClinicManagementSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; }
        public string VisitType { get; set; }
        public string ?Notes { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int ScheduleId { get; set; }
        public DoctorSchedule DoctorSchedule { get; set; }
    }
}
