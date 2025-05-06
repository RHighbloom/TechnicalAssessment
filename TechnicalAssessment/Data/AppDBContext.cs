using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Models.Entities;

namespace TechnicalAssessment.Data
{
    public class AppDBContext : DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDB");
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<School> Schools { get; set; }
    }
}