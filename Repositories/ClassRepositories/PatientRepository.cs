using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class PatientRepository:IPatientRepository
    {
        private readonly ClincDBContext _context;
        public PatientRepository(ClincDBContext clincDBContext)
        { 
            _context = clincDBContext;
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.Include(p => p.PatientAddresses)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }
    }
}
