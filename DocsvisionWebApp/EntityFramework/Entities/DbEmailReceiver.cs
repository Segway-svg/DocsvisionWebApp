using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbEmailReceiver
{
    public Guid Id { get; set; }
    public Guid EmailId { get; set; }
    public DbEmail Email { get; set; }
    public Guid ReceiverId { get; set; }
    public DbReceiver Receiver { get; set; }
}

public class DbEmailsReceiversConfiguration : IEntityTypeConfiguration<DbEmailReceiver>
{
    public void Configure(EntityTypeBuilder<DbEmailReceiver> builder)
    {
        builder
            .ToTable("EmailsReceivers");
        builder
            .HasKey(l => l.Id);

        builder
            .HasOne(s => s.Email)
            .WithMany(s => s.EmailsReceivers)
            .HasForeignKey(s => s.EmailId);

        builder
            .HasOne(s => s.Receiver)
            .WithMany(s => s.EmailsReceivers)
            .HasForeignKey(s => s.ReceiverId);
    }
}