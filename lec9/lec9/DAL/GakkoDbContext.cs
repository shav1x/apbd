using lec9.Models;
using Microsoft.EntityFrameworkCore;

namespace lec9.DAL;

public class GakkoDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentGroup> StudentGroup { get; set; }

    protected GakkoDbContext()
    {
        
    }

    public GakkoDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        
    }
}
