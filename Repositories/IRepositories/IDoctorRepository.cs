using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        //عملتها bool علشان لو احتاجت اتاكد اتحفظ ولا لاء فا اشوف لو رجع true
        Task<bool> SaveChangesAsync();

    }
}
