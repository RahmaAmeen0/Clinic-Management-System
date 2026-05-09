using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly ClincDBContext _context;
        public DepartmentRepository(ClincDBContext clincDBContext)
        {
            _context = clincDBContext;
        }

        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
        }

        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
        }
    }
}
