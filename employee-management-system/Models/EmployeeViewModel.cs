using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace employee_management_system.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [DisplayName("Full Name")]
        public string Name { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNo { get; set; }
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
    }
}
