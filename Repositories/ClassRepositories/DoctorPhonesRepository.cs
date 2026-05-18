using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class DoctorPhonesRepository : IDoctorPhonesRepository
    {
        private readonly ClincDBContext _context;

        public DoctorPhonesRepository(ClincDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(DoctorPhones doctorPhone)
        {
            await _context.DoctorPhones.AddAsync(doctorPhone);
        }

        public void Delete(DoctorPhones doctorPhone)
        {
            _context.DoctorPhones.Remove(doctorPhone);
        }

        public async Task<IEnumerable<DoctorPhones>> GetAllAsync()
        {
            return await _context.DoctorPhones.Include(d => d.Doctor).ToListAsync();
        }

        public async Task<IEnumerable<DoctorPhones>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.DoctorPhones
                .Include(d => d.Doctor)
                .Where(d => d.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(DoctorPhones doctorPhone)
        {
            _context.DoctorPhones.Update(doctorPhone);
        }
    }
}