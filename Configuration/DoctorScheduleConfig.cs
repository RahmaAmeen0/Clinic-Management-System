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
                new DoctorSchedule
                {
                    Id = 1,
                    WorkDay = "Sunday",
                    StartTime = new TimeSpan(9, 0, 0), 
                    EndTime = new TimeSpan(15, 0, 0),  
                    DoctorId = 1
                }
            );
        }
    }
}
