namespace ClinicManagementSystem.Models
{
    public class DoctorAddress
    {
        public string Address { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
