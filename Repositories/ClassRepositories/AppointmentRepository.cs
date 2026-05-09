using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClincDBContext _context;

        public AppointmentRepository(ClincDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(Appointment appointment)
        {
             await _context.Appointments.AddAsync(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
           return  await _context.Appointments.Include(a=>a.Patient)
                .Include(a=>a.DoctorSchedule).ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments.Include(a => a.Patient)
                .Include(a => a.DoctorSchedule).FirstOrDefaultAsync(a=>a.Id == id);
         }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);

        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }
    }
}
