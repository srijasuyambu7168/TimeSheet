using Microsoft.EntityFrameworkCore;
using System;

namespace TimesheetApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
    }
}
