using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Type)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Description)
                   .HasMaxLength(500);

            builder.HasData(
                new Department { Id = 1, Type = "General Medicine", Description = "Main Clinic" },
                new Department { Id = 2, Type = "Surgery", Description = "Surgical Dept" },
                new Department { Id = 3, Type = "Pediatrics", Description = "Children's Health Clinic" },
                new Department { Id = 4, Type = "Dentistry", Description = "Dental Care Clinic" }
            );
        }
    }
}