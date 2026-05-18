using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IDoctorPhonesRepository
    {
        Task<IEnumerable<DoctorPhones>> GetAllAsync();
        Task<IEnumerable<DoctorPhones>> GetByDoctorIdAsync(int doctorId);
        Task AddAsync(DoctorPhones doctorPhone);
        void Update(DoctorPhones doctorPhone);
        void Delete(DoctorPhones doctorPhone);
        Task<bool> SaveChangesAsync();
    }
}