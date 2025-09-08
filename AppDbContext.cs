using Microsoft.EntityFrameworkCore;
using TimesheetApp.Models;

namespace TimesheetApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
    }
}
