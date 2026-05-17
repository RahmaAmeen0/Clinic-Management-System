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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            var departments =  await _departmentRepo.GetAllAsync();
            appointmentViewModel.DepartmentsList = departments.Select(d => new SelectListItem
            {
                Text = d.Type,
                Value=d.Id.ToString()
            }
            ).ToList();
            var doctors = await _doctorRepo.GetAllAsync();
            appointmentViewModel.DoctorsList = doctors.Select(d => new SelectListItem
            {
                Text = $"Dr. {d.FirstName} {d.LastName}",
                Value = d.Id.ToString()
            }).ToList();
            var doctorSchdule = await _scheduleRepo.GetAllAsync();
            appointmentViewModel.SchedulesList = doctorSchdule.Select(s => new SelectListItem
            {
                Text = $"{s.WorkDay} ({s.StartTime} - {s.EndTime})",
                Value = s.Id.ToString()
            }).ToList();
            return View (appointmentViewModel);
        }


    }
}
