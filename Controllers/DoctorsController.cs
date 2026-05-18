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
        public async Task<IActionResult>Index()
        {
            var Resualt = await _repository.GetAllAsync();
            var doctore=Resualt.ToList();
            var Response = _mapper.Map<List<DoctorsViewModel>>(doctore);


            return View(Response);

        }
    }
}
