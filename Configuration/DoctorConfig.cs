using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.DoctorId);
            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Doctor { DoctorId = 1, FirstName = "Ahmed", LastName = "Belal", Specialization = "Cardiology", DoctorGender = "Male", DepartmentId = 1 },
                new Doctor { DoctorId = 2, FirstName = "Mohamed", LastName = "Radwan", Specialization = "Orthopedics", DoctorGender = "Male", DepartmentId = 2 },
                new Doctor { DoctorId = 3, FirstName = "Abdelrahman", LastName = "Mosa", Specialization = "Pediatrics", DoctorGender = "Female", DepartmentId = 3 },
                new Doctor { DoctorId = 4, FirstName = "Rahma", LastName = "Ameen", Specialization = "Dentistry", DoctorGender = "Female", DepartmentId = 4 },
                new Doctor { DoctorId = 5, FirstName = "Samira", LastName = "Kamal", Specialization = "Internal Medicine", DoctorGender = "Male", DepartmentId = 1 },
                new Doctor { DoctorId = 6, FirstName = "Mariam", LastName = "Tarek", Specialization = "General Surgery", DoctorGender = "Female", DepartmentId = 2 }
            );
        }
    }
}