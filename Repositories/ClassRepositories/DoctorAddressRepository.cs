using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class DoctorAddressRepository : IDoctorAddressRepository
    {
        private readonly ClincDBContext _context;

        public DoctorAddressRepository(ClincDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(DoctorAddress doctorAddress)
        {
            await _context.DoctorAddresses.AddAsync(doctorAddress);
        }

        public void Delete(DoctorAddress doctorAddress)
        {
            _context.DoctorAddresses.Remove(doctorAddress);
        }

        public async Task<IEnumerable<DoctorAddress>> GetAllAsync()
        {
            return await _context.DoctorAddresses.Include(d => d.Doctor).ToListAsync();
        }

        public async Task<IEnumerable<DoctorAddress>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.DoctorAddresses
                .Include(d => d.Doctor)
                .Where(d => d.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(DoctorAddress doctorAddress)
        {
            _context.DoctorAddresses.Update(doctorAddress);
        }
    }
}