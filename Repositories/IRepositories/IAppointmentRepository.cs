using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task AddAsync(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
        //عملتها bool علشان لو احتاجت اتاكد اتحفظ ولا لاء فا اشوف لو رجع true
        Task<bool> SaveChangesAsync();

    }
}
