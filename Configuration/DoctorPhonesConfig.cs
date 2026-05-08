using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class DoctorPhonesConfig : IEntityTypeConfiguration<DoctorPhones>
    {
        public void Configure(EntityTypeBuilder<DoctorPhones> builder)
        {
            builder.HasKey(dp => new { dp.Phone, dp.DoctorId });

            builder.Property(dp => dp.Phone).HasMaxLength(15);

            builder.HasData(
            new DoctorPhones 
            { Phone = "0100200300",
              DoctorId = 1 });
        }
    }
}
