using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModels;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClinicManagementSystem.Context;


namespace ClinicManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly ClincDBContext _context; 

        public HomeController(
            IDepartmentRepository departmentRepo,
            IDoctorRepository doctorRepo,
            ClincDBContext context)
        {
            _departmentRepo = departmentRepo;
            _doctorRepo = doctorRepo;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                Departments = await _departmentRepo.GetAllAsync(),
                Doctors = await _doctorRepo.GetAllAsync()
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(model);
                await _context.SaveChangesAsync();

                // رسالة النجاح
                TempData["SuccessMessage"] = "Your message has been sent successfully! Our team will contact you soon.";

                return RedirectToAction(nameof(Contact));
            }
            return View(model);
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}