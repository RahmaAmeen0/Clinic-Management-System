using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Context
{
    public class ClincDBContext: IdentityDbContext<IdentityUser>
    {
        public ClincDBContext() { }
        public ClincDBContext(DbContextOptions<ClincDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClincDBContext).Assembly);
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual  DbSet<Patient> Patients { get; set; }
        public virtual  DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public virtual DbSet<DoctorPhones> DoctorPhones { get; set; }
        public virtual DbSet<DoctorAddress> DoctorAddresses { get; set; }
        public virtual DbSet<PatientAddresses> PatientAddresses { get; set; }
        public virtual DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
