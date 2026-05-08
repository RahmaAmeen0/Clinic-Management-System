using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);

            builder.HasData(
            new Doctor
            {
                Id = 1,
                FirstName = "Ahmed",
                LastName = "Hassan",
                Specialization = "Cardiology",
                DoctorGender = "Male",
                DepartmentId = 1
            });
        }
    }
}
