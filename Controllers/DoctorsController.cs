using Azure;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using ClinicManagementSystem.ViewModels;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper  _mapper;

        public DoctorsController(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Index(int? departmentId)
        {
            var result = await _repository.GetAllAsync();
            var doctors = result.ToList();

            if (departmentId.HasValue)
            {
                doctors = doctors.Where(d => d.DepartmentId == departmentId.Value).ToList();
            }

            var response = _mapper.Map<List<DoctorsViewModel>>(doctors);

            return View(response);
        }
    }
}
