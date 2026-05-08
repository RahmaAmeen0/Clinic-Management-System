using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Phone).HasMaxLength(15);
            builder.Property(p => p.Gender).HasMaxLength(10);

            builder.HasData(
                new Patient
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Mansour",
                    Age = 25,
                    Gender = "Male",
                    Phone = "0123445566"
                }
            );
        }

    }
}
