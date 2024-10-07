using MainApp.EntitesConfiguration;
using MainApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace MainApp.DataContext;

public class WebAppDbContext:DbContext
{
    public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options) { }
    
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfig());
    }
}