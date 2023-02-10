using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework;

public class EmailDbContext : DbContext
{
    public DbSet<DbEmail> Emails { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost\sqlexpress;Database=LettersDB;Trusted_Connection=True;TrustServerCertificate=True");
    }
}