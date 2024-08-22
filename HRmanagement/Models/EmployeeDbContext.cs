using Microsoft.EntityFrameworkCore;



namespace HRmanagement.Models
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Employee> Employees { get; set; }
    }
}
