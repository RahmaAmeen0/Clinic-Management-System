using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IDoctorScheduleRepository
    {
        Task<IEnumerable<DoctorSchedule>> GetAllAsync();
        Task<DoctorSchedule?> GetByIdAsync(int? id);
        Task AddAsync(DoctorSchedule doctorSchedule);
        void Update(DoctorSchedule doctorSchedule);
        void Delete(DoctorSchedule doctorSchedule);
        Task<bool> SaveChangesAsync();
        
    }
}
