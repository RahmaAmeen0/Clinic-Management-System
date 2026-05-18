using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IDoctorAddressRepository
    {
        Task<IEnumerable<DoctorAddress>> GetAllAsync();
        Task<IEnumerable<DoctorAddress>> GetByDoctorIdAsync(int doctorId);
        Task AddAsync(DoctorAddress doctorAddress);
        void Update(DoctorAddress doctorAddress);
        void Delete(DoctorAddress doctorAddress);
        Task<bool> SaveChangesAsync();
    }
}