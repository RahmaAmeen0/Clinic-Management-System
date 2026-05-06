using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class PatientAddressesConfig : IEntityTypeConfiguration<PatientAddresses>
    {
        public void Configure(EntityTypeBuilder<PatientAddresses> builder)
        {
            builder.HasKey(pa => new { pa.Address, pa.PatientId });

            builder.HasData(
            new PatientAddresses
            { Address = "Giza, Pyramids St.",
              PatientId = 1 });
        }
    }
}
