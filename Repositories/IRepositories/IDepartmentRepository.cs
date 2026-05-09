using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Repositories.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task AddAsync(Department department);
        void Update(Department department);
        void Delete(Department department);
        //عملتها bool علشان لو احتاجت اتاكد اتحفظ ولا لاء فا اشوف لو رجع true
        Task<bool> SaveChangesAsync();
    }
}
