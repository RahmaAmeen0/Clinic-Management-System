namespace ClinicManagementSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<PatientAddresses> PatientAddresses { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
