using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.ViewModels
{
    public class AppointmentViewModel
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        [MaxLength(50, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        [MaxLength(50, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Please enter a valid age between 1 and 120.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please select your gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }

       
        [Required(ErrorMessage = "Please select a visit type.")]
        public string VisitType { get; set; }

        //علشان نخزن فيها الملاحظات الى جاية من ال user
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string ? Notes { get; set; }
       

       

        [Required(ErrorMessage = "Please select an appointment time.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid time slot.")]
        public int ScheduleId { get; set; }
        [Required(ErrorMessage = "Please select a doctor.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid doctor.")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Please select a department.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid department.")]
        public int DepartmentId { get; set; }

        //علشان لما نعرضهم كا قوائم فى ال html
        public IEnumerable<SelectListItem>? DepartmentsList { get; set; }
        public IEnumerable<SelectListItem>? DoctorsList { get; set; }
        public IEnumerable<SelectListItem>? SchedulesList { get; set; }
    }
}
