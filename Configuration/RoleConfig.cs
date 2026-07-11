using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementSystem.Configuration
{
    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "7ca929d2-7ec5-40b9-8137-bc6fa44a56a1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "1" // ثبتنا القيمة هنا
                },
                new IdentityRole
                {
                    Id = "8b2345d2-8ec5-41b9-9248-bc6fa44a56b2",
                    Name = "Doctor",
                    NormalizedName = "DOCTOR",
                    ConcurrencyStamp = "2" // وثبتناها هنا
                },
                new IdentityRole
                {
                    Id = "9c3456d3-9ec6-42b9-0359-bc6fa44a56c3",
                    Name = "Patient",
                    NormalizedName = "PATIENT",
                    ConcurrencyStamp = "3" // وثبتناها هنا
                }
            );
        }
    }
}