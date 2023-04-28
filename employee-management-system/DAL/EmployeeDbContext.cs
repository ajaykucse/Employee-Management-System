using employee_management_system.Models.DBEntites;
using Microsoft.EntityFrameworkCore;

namespace employee_management_system.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
