using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework;

public class EmailDbContext : DbContext
{
    public DbSet<DbEmail> Emails { get; set; }
    public DbSet<DbReceiver> Receivers { get; set; }
    public DbSet<DbSender> Senders { get; set; }
    public DbSet<DbEmailReceiver> EmailsReceivers { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost\sqlexpress;Database=LettersDB;Trusted_Connection=True;TrustServerCertificate=True");
    }
}