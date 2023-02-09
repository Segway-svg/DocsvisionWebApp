using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbEmail
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Receiver { get; set; }
    public string Sender { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
}

public class DbGroupConfiguration : IEntityTypeConfiguration<DbEmail>
{
    public void Configure(EntityTypeBuilder<DbEmail> builder)
    {
        builder
            .ToTable("Emails");
        builder
            .HasKey(l => l.Id);
    }
}