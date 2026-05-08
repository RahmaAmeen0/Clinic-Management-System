namespace ClinicManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string DoctorGender { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<DoctorPhones> DoctorPhones { get; set; }
        public virtual ICollection<DoctorAddress> DoctorAddresses { get; set; }
        public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
