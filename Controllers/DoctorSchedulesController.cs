using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using ClinicManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class DoctorSchedulesController : Controller
    {
        private readonly IDoctorScheduleRepository _scheduleRepo;

  
        public DoctorSchedulesController(IDoctorScheduleRepository scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }

        
        public async Task<IActionResult> Index(int doctorId)
        {
            var allSchedules = await _scheduleRepo.GetAllAsync();

           
            var doctorSchedules = allSchedules.Where(s => s.DoctorId == doctorId).ToList();

            if (!doctorSchedules.Any())
            {
                ViewBag.Message = "No schedules recorded for this doctor at the moment.";
                return View(new DoctorScheduleViewModel { DoctorId = doctorId });
            }

            
            var doctorInfo = doctorSchedules.First().Doctor;

            var viewModel = new DoctorScheduleViewModel
            {
                DoctorId = doctorId,
                DoctorName = $"Dr. {doctorInfo.FirstName} {doctorInfo.LastName}",
                Specialization = doctorInfo.Specialization,
                Schedules = doctorSchedules.Select(s => new ScheduleItemViewModel
                {
                    ScheduleId = s.Id,
                    WorkDay = s.WorkDay,
                    StartTimeFormatted = DateTime.Today.Add(s.StartTime).ToString("hh:mm tt"),
                    EndTimeFormatted = DateTime.Today.Add(s.EndTime).ToString("hh:mm tt")
                }).ToList()
            };

            return View(viewModel);
        }

       
        [HttpGet]
        public IActionResult Create(int doctorId)
        {
            var model = new CreateScheduleViewModel { DoctorId = doctorId };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateScheduleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newSchedule = new DoctorSchedule
                {
                    DoctorId = model.DoctorId,
                    WorkDay = model.WorkDay,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime
                };

                await _scheduleRepo.AddAsync(newSchedule);

               
                bool isSaved = await _scheduleRepo.SaveChangesAsync();

                if (isSaved)
                {
                    return RedirectToAction(nameof(Index), new { doctorId = model.DoctorId });
                }

                ModelState.AddModelError("", "An error occurred while saving data.");
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var schedule = await _scheduleRepo.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            
            var model = new CreateScheduleViewModel
            {
                Id = schedule.Id,
                DoctorId = schedule.DoctorId,
                WorkDay = schedule.WorkDay,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime
            };

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateScheduleViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var existingSchedule = await _scheduleRepo.GetByIdAsync(model.Id);
                if (existingSchedule == null)
                {
                    return NotFound();
                }

                
                existingSchedule.WorkDay = model.WorkDay;
                existingSchedule.StartTime = model.StartTime;
                existingSchedule.EndTime = model.EndTime;

                _scheduleRepo.Update(existingSchedule);
                bool isSaved = await _scheduleRepo.SaveChangesAsync();

                if (isSaved)
                {
                    return RedirectToAction(nameof(Index), new { doctorId = existingSchedule.DoctorId });
                }

                ModelState.AddModelError("", "An error occurred while saving data.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var schedule = await _scheduleRepo.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            int doctorId = schedule.DoctorId; 
            _scheduleRepo.Delete(schedule);
            await _scheduleRepo.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { doctorId = doctorId });
        }
        [HttpGet]
        public async Task<IActionResult> PatientView(int? departmentId, int? doctorId)
        {
            var allSchedules = await _scheduleRepo.GetAllAsync();

            var filteredSchedules = allSchedules
                .Where(s => s.Appointments == null || !s.Appointments.Any())
                .AsQueryable();


            if (departmentId.HasValue)
            {
                filteredSchedules = filteredSchedules
                    .Where(s => s.Doctor.DepartmentId == departmentId);
            }
            if (doctorId.HasValue)
            {
                filteredSchedules = filteredSchedules
                    .Where(s => s.DoctorId == doctorId);
            }

            var departments = allSchedules
                .Where(s => s.Doctor != null && s.Doctor.Department != null)
                .Select(s => new { Id = s.Doctor.Department.Id, Name = s.Doctor.Department.Type })
                .GroupBy(d => d.Id)
                .Select(g => g.First())
                .ToList();

            var doctorsList = allSchedules
                .Where(s => s.Doctor != null)
                .Select(s => s.Doctor);

            if (departmentId.HasValue)
            {
                doctorsList = doctorsList.Where(d => d.DepartmentId == departmentId);
            }

            var uniqueDoctors = doctorsList
                .GroupBy(d => d.DoctorId)
                .Select(g => g.First())
                .Select(d => new { Id = d.DoctorId, Name = $"Dr. {d.FirstName} {d.LastName}" })
                .ToList();

            ViewBag.Departments = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(departments, "Id", "Name", departmentId);
            ViewBag.Doctors = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(uniqueDoctors, "Id", "Name", doctorId);

            var viewModel = filteredSchedules.Select(s => new ScheduleItemViewModel
            {
                ScheduleId = s.Id,
                WorkDay = s.WorkDay,
                StartTimeFormatted = DateTime.Today.Add(s.StartTime).ToString("hh:mm tt"),
                EndTimeFormatted = DateTime.Today.Add(s.EndTime).ToString("hh:mm tt"),
                DoctorName = s.Doctor != null ? $"Dr. {s.Doctor.FirstName} {s.Doctor.LastName}" : "Doctor Available",
                Specialization = s.Doctor != null ? s.Doctor.Specialization : "Clinic Specialist"
            }).ToList();

            return View(viewModel);
        }
    }
}
