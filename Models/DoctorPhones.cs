namespace ClinicManagementSystem.Models
{
    public class DoctorPhones
    {
        public string Phone { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
