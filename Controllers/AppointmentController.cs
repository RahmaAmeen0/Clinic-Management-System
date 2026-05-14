using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using ClinicManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicManagementSystem.Controllers
{
    public class AppointmentController : Controller 
    {
        private readonly IPatientRepository _patientRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IDoctorScheduleRepository _scheduleRepo;
        public AppointmentController(IPatientRepository patientRepo,
            IDepartmentRepository departmentRepo, IAppointmentRepository appointmentRepo,
            IDoctorRepository doctorRepo, IDoctorScheduleRepository scheduleRepo)
        {
            _patientRepo = patientRepo;
            _departmentRepo = departmentRepo;
            _appointmentRepo = appointmentRepo;
            _doctorRepo = doctorRepo;
            _scheduleRepo = scheduleRepo;
        }
        
    }
}
