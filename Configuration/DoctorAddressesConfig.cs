using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class DoctorAddressesConfig : IEntityTypeConfiguration<DoctorAddress>
    {
        public void Configure(EntityTypeBuilder<DoctorAddress> builder)
        {
            builder.HasKey(da => new { da.Address, da.DoctorId });

            builder.HasData(
            new DoctorAddress
            { Address = "Cairo, Abbasia St.",
              DoctorId = 1 });
        }
    }
}
