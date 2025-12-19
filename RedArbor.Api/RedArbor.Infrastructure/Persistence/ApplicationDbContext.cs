using Microsoft.EntityFrameworkCore;
using RedArbor.Domain.Entities;

namespace RedArbor.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.Username).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.UpdatedOn).IsRequired();
        });
    }
}