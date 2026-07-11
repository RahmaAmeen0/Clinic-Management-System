using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();

            return View(departments);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            Console.WriteLine("CREATE HIT");

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            if (ModelState.IsValid)
            {
                await _departmentRepository.AddAsync(department);

                var result = await _departmentRepository.SaveChangesAsync();

                Console.WriteLine($"SAVE RESULT: {result}");

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // POST: Department/Edit/5
        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _departmentRepository.Update(department);

                await _departmentRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            _departmentRepository.Delete(department);

            await _departmentRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
    }
}