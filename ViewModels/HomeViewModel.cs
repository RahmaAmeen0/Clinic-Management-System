using ClinicManagementSystem.Models;
using System.Collections.Generic;

namespace ClinicManagementSystem.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}