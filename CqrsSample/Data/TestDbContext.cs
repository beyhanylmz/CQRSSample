using CqrsSample.Models;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Data;

public class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=TestDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
