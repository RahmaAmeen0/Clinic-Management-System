namespace ClinicManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
