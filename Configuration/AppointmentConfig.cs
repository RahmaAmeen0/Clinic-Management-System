using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Status).HasMaxLength(20); 
            builder.Property(a => a.VisitType).HasMaxLength(50);     

            builder.HasOne(a => a.Patient)
                   .WithMany(p => p.Appointments)
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(a => a.DoctorSchedule)
                   .WithMany(s => s.Appointments)
                   .HasForeignKey(a => a.ScheduleId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Appointment
                {
                    Id = 1,
                    Date = new DateTime(2026, 5, 20),
                    Time = new TimeSpan(10, 30, 0),
                    Status = "Confirmed",
                    VisitType = "Consultation",
                    PatientId = 1,
                    ScheduleId = 1
                }
            );
        }
    }
}
