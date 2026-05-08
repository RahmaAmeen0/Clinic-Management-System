namespace ClinicManagementSystem.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public string WorkDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
