using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IPatientAddressesRepository
    {
        Task<IEnumerable<PatientAddresses>> GetAllAsync();
        Task<IEnumerable<PatientAddresses>> GetByPatientIdAsync(int patientId);
        Task AddAsync(PatientAddresses patientAddress);
        void Update(PatientAddresses patientAddress);
        void Delete(PatientAddresses patientAddress);
        Task<bool> SaveChangesAsync();
    }
}