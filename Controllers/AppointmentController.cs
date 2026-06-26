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
        private readonly IPatientAddressesRepository _patientAddressRepo;
        public AppointmentController(IPatientRepository patientRepo,
            IDepartmentRepository departmentRepo, IAppointmentRepository appointmentRepo,
            IDoctorRepository doctorRepo, IDoctorScheduleRepository scheduleRepo, IPatientAddressesRepository patientAddressRepo)
        {
            _patientRepo = patientRepo;
            _departmentRepo = departmentRepo;
            _appointmentRepo = appointmentRepo;
            _doctorRepo = doctorRepo;
            _scheduleRepo = scheduleRepo;
            _patientAddressRepo = patientAddressRepo;
        }
        [HttpGet]
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Create(int? scheduleId, int? departmentId, int? doctorId)
        {
            AppointmentViewModel appointmentVM = new AppointmentViewModel();

            // 1. شحن الأقسام دايماً
            var allDepartments = await _departmentRepo.GetAllAsync();
            appointmentVM.DepartmentsList = allDepartments
                                            .Select(d => new SelectListItem { Text = d.Type, Value = d.Id.ToString() })
                                            .ToList();

            appointmentVM.DoctorsList = new List<SelectListItem>();
            appointmentVM.SchedulesList = new List<SelectListItem>();

            // 2. لو جاي من صفحة المواعيد (معاه ScheduleId)
            if (scheduleId.HasValue)
            {
                var schedule = await _scheduleRepo.GetByIdAsync(scheduleId.Value);
                if (schedule != null)
                {
                    doctorId = schedule.DoctorId; // بنخلي الـ doctorId ياخد قيمته من الميعاد عشان يكمل في اللوجيك اللي تحت
                    appointmentVM.ScheduleId = schedule.Id;
                }
            }

            // 3. لو جاي من صفحة الدكاترة أو المواعيد (معاه DoctorId)
            if (doctorId.HasValue)
            {
                var doctor = await _doctorRepo.GetByIdAsync(doctorId.Value);
                if (doctor != null)
                {
                    appointmentVM.DoctorId = doctor.DoctorId;
                    appointmentVM.DepartmentId = doctor.DepartmentId;

                    // نملى قائمة الدكاترة بنفس قسم الدكتور ده
                    var departmentDoctors = (await _doctorRepo.GetAllAsync()).Where(d => d.DepartmentId == doctor.DepartmentId);
                    appointmentVM.DoctorsList = departmentDoctors
                        .Select(d => new SelectListItem { Text = $"Dr. {d.FirstName} {d.LastName}", Value = d.DoctorId.ToString() })
                        .ToList();

                    // نملى قائمة المواعيد الخاصة بالدكتور ده بنظام 12 ساعة
                    var doctorSchedules = (await _scheduleRepo.GetAllAsync()).Where(s => s.DoctorId == doctor.DoctorId);
                    appointmentVM.SchedulesList = doctorSchedules
                        .Select(s => new SelectListItem { Text = $"{s.WorkDay} ({DateTime.Today.Add(s.StartTime).ToString("hh:mm tt")} - {DateTime.Today.Add(s.EndTime).ToString("hh:mm tt")})", Value = s.Id.ToString() })
                        .ToList();
                }
            }
            // 4. لو جاي من صفحة الأقسام (معاه DepartmentId بس)
            else if (departmentId.HasValue)
            {
                appointmentVM.DepartmentId = departmentId.Value;

                var departmentDoctors = (await _doctorRepo.GetAllAsync()).Where(d => d.DepartmentId == departmentId.Value);
                appointmentVM.DoctorsList = departmentDoctors
                    .Select(d => new SelectListItem { Text = $"Dr. {d.FirstName} {d.LastName}", Value = d.DoctorId.ToString() })
                    .ToList();
            }

            return View(appointmentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentViewModel appointmentVM)
        {
            //لو البيانات مش صح فا لازم يعرض القوائم تانى
            if (!ModelState.IsValid)
            {
                appointmentVM.DepartmentsList = (await _departmentRepo.GetAllAsync()).Select(d => new SelectListItem { Text = d.Type, Value = d.Id.ToString() }).ToList();
                appointmentVM.DoctorsList = (await _doctorRepo.GetAllAsync()).Select(d => new SelectListItem { Text = $"Dr. {d.FirstName} {d.LastName}", Value = d.DoctorId.ToString() }).ToList();
                appointmentVM.SchedulesList = (await _scheduleRepo.GetAllAsync()).Select(s => new SelectListItem { Text = $"{s.WorkDay} ({s.StartTime} - {s.EndTime})", Value = s.Id.ToString() }).ToList();

                return View(appointmentVM);
            }

            Patient patient = new Patient
            {
                FirstName = appointmentVM.FirstName,
                LastName = appointmentVM.LastName,
                Age = appointmentVM.Age,
                Phone = appointmentVM.Phone,
                Gender = appointmentVM.Gender
            };

            await _patientRepo.AddAsync(patient);
            await _patientRepo.SaveChangesAsync(); // الداتا بيز هتديله Id دلوقتي

            PatientAddresses patientAddress = new PatientAddresses
            {
                PatientId = patient.Id, // بنربط العنوان بـ Id المريض اللي لسه طالع
                Address = appointmentVM.Address
            };

            await _patientAddressRepo.AddAsync(patientAddress);
            await _patientAddressRepo.SaveChangesAsync(); // بنحفظ العنوان في جدوله

            Appointment appointment = new Appointment
            {
                PatientId = patient.Id,
                ScheduleId = appointmentVM.ScheduleId,

                VisitType = appointmentVM.VisitType,
                Notes = appointmentVM.Notes,
                //خلينا قيمه افراضيه يفضل الحالة انتظار لحد ما الادمن يعدل من لوحة التحكم انه خلاص اتقبل
                Status = "Pending",
                //علشان الوقت والتاريخ يتسجلوا تلقائى فى الداتا بيز
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay
            };

            await _appointmentRepo.AddAsync(appointment);
            await _appointmentRepo.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<JsonResult> GetSchedulesByDoctor(int doctorId)
        {
            // بنجيب كل المواعيد ونفلترها برقم الدكتور اللي المريض اختاره
            var schedules = (await _scheduleRepo.GetAllAsync())
                            .Where(s => s.DoctorId == doctorId)
                            .Select(s => new {
                                id = s.Id,
                                text = $"{s.WorkDay} ({s.StartTime:hh\\:mm} - {s.EndTime:hh\\:mm})"
                            });

            return Json(schedules); // بنرجعها كـ JSON عشان الـ JavaScript يفهمها
        }
        [HttpGet]
        public async Task<JsonResult> GetDoctorsByDepartment(int departmentId)
        {
            var doctors = (await _doctorRepo.GetAllAsync())
                          .Where(d => d.DepartmentId == departmentId)
                          .Select(d => new {
                              id = d.DoctorId, // الـ Primary Key الجديد بتاع الدكتور
                              text = $"Dr. {d.FirstName} {d.LastName}"
                          });

            return Json(doctors);
        }
    }
}
