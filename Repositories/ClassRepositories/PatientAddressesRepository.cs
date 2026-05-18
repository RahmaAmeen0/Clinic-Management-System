using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class PatientAddressesRepository : IPatientAddressesRepository
    {
        private readonly ClincDBContext _context;

        public PatientAddressesRepository(ClincDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(PatientAddresses patientAddress)
        {
            await _context.PatientAddresses.AddAsync(patientAddress);
        }

        public void Delete(PatientAddresses patientAddress)
        {
            _context.PatientAddresses.Remove(patientAddress);
        }

        public async Task<IEnumerable<PatientAddresses>> GetAllAsync()
        {
            return await _context.PatientAddresses.Include(p => p.Patient).ToListAsync();
        }

        public async Task<IEnumerable<PatientAddresses>> GetByPatientIdAsync(int patientId)
        {
            return await _context.PatientAddresses
                .Include(p => p.Patient)
                .Where(p => p.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(PatientAddresses patientAddress)
        {
            _context.PatientAddresses.Update(patientAddress);
        }
    }
}