using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicManagementSystem.Repositories.ClassRepositories
{
    public class DoctorScheduleRepository:IDoctorScheduleRepository
    {
        private readonly ClincDBContext _context;
        public DoctorScheduleRepository(ClincDBContext clincDBContext)
        {
            _context = clincDBContext;
        }

        public async Task AddAsync(DoctorSchedule doctorSchedule)
        {
            await _context.DoctorSchedules.AddAsync(doctorSchedule);
        }

        public void Delete(DoctorSchedule doctorSchedule)
        {
            _context.DoctorSchedules.Remove(doctorSchedule);
        }

        public async Task<IEnumerable<DoctorSchedule>> GetAllAsync()
        {
            return await _context.DoctorSchedules.Include(s => s.Doctor).ToListAsync();
        }

        public async Task<DoctorSchedule> GetByIdAsync(int? id)
        {
            if (id == null) return null;

            return await _context.DoctorSchedules.Include(s => s.Doctor)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(DoctorSchedule doctorSchedule)
        {
            _context.DoctorSchedules.Update(doctorSchedule);
        }
    }
}
