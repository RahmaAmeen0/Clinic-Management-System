using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class DoctorScheduleConfig : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.WorkDay).IsRequired().HasMaxLength(20);

            builder.HasOne(s => s.Doctor)
                   .WithMany(d => d.DoctorSchedules)
                   .HasForeignKey(s => s.DoctorId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new DoctorSchedule { Id = 1, WorkDay = "Sunday", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(15, 0, 0), DoctorId = 1 },
                new DoctorSchedule { Id = 2, WorkDay = "Tuesday", StartTime = new TimeSpan(12, 0, 0), EndTime = new TimeSpan(18, 0, 0), DoctorId = 1 },
                new DoctorSchedule { Id = 3, WorkDay = "Monday", StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(14, 0, 0), DoctorId = 2 },
                new DoctorSchedule { Id = 4, WorkDay = "Wednesday", StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(21, 0, 0), DoctorId = 2 },
                new DoctorSchedule { Id = 5, WorkDay = "Thursday", StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(14, 0, 0), DoctorId = 3 },
                new DoctorSchedule { Id = 6, WorkDay = "Saturday", StartTime = new TimeSpan(15, 0, 0), EndTime = new TimeSpan(20, 0, 0), DoctorId = 3 },
                new DoctorSchedule { Id = 7, WorkDay = "Sunday", StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(22, 0, 0), DoctorId = 4 },
                new DoctorSchedule { Id = 8, WorkDay = "Tuesday", StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(16, 0, 0), DoctorId = 4 },
                new DoctorSchedule { Id = 9, WorkDay = "Monday", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), DoctorId = 5 },
                new DoctorSchedule { Id = 10, WorkDay = "Wednesday", StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(19, 0, 0), DoctorId = 6 }
            );
        }
    }
}