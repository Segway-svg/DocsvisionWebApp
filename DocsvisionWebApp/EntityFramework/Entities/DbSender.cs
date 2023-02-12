using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbSender
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<DbEmail> Emails { get; set; } = new List<DbEmail>();
}

public class DbGroupConfiguration : IEntityTypeConfiguration<DbSender>
{
    public void Configure(EntityTypeBuilder<DbSender> builder)
    {
        builder
            .ToTable("Senders");
        builder
            .HasKey(l => l.Id);
        builder
            .HasMany(l => l.Emails)
            .WithOne(r => r.Sender);
    }
}