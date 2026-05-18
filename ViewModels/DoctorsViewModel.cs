using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.ViewModels
{
    public class DoctorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }= string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string DoctorGender { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
