using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task AddAsync(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
        //عملتها bool علشان لو احتاجت اتاكد اتحفظ ولا لاء فا اشوف لو رجع true
        Task<bool> SaveChangesAsync();
    }
}
