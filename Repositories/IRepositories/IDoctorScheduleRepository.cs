using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IDoctorScheduleRepository
    {
        Task<IEnumerable<DoctorSchedule>> GetAllAsync();
        Task<DoctorSchedule?> GetByIdAsync(int id);
        Task AddAsync(DoctorSchedule doctorSchedule);
        void Update(DoctorSchedule doctorSchedule);
        void Delete(DoctorSchedule doctorSchedule);
        //عملتها bool علشان لو احتاجت اتاكد اتحفظ ولا لاء فا اشوف لو رجع true
        Task<bool> SaveChangesAsync();
    }
}
