using ClinicManagementSystem.Context;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repositories.ClassRepositories;
using ClinicManagementSystem.Repositories.IRepositories;
using ClinicManagementSystem.ViewModels;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().
                AddEntityFrameworkStores<ClincDBContext>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ClincDBContext>(options =>
                options.UseSqlServer(connectionString));

            //adding mapsetr config
            var config = TypeAdapterConfig.GlobalSettings;
            // Doctor => DoctorViewModel
            config.NewConfig<Doctor, DoctorsViewModel>()
            .Map(dest => dest.DepartmentName,
         src => src.Department.Description);
            // Register Mapster Services
            //builder.Services.AddSingleton(config);

            builder.Services.AddSingleton<IMapper>(new Mapper(config));

            
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseAuthentication();    
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
