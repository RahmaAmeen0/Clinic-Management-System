using Microsoft.AspNetCore.Identity;

namespace ClinicManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // الخصائص الإضافية للمستقبل
        public string? ProfilePicture { get; set; } // صورة البروفايل
        public string? Gender { get; set; } // النوع (ذكر/أنثى)
        public DateTime CreatedAt { get; set; } = DateTime.Now; // وقت التسجيل
        public bool IsActive { get; set; } = true; // لو حبيت توقف حساب يوزر من لوحة التحكم
    }
}