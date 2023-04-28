using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employee_management_system.Models.DBEntites
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string JobTitle { get; set; }
    }
}
