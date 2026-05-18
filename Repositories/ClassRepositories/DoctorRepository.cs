using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly ClincDBContext _context;
        public DoctorRepository(ClincDBContext clincDBContext)
        {
            _context = clincDBContext;
            
        }
        public async Task AddAsync(Doctor doctor)
        {
            await _context.AddAsync(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.Include(d=>d.Department).ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
          return  await _context.Doctors.Include(d=>d.Department).Include(d=>d.DoctorAddresses).
                Include(d=>d.DoctorPhones).FirstOrDefaultAsync(d=>d.DoctorId==id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }
    }
}
