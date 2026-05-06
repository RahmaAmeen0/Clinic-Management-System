namespace ClinicManagementSystem.Models
{
    public class PatientAddresses
    {
        public string Address { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
