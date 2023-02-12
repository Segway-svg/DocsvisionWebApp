using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework.Repositories;

public class SenderRepository
{
    public async Task<Guid?> CreateSenderAsync(DbSender sender)
    {
        using (var dbContext = new EmailDbContext())
        {
            dbContext.Database.Migrate();
            dbContext.Senders.Add(sender);
            await dbContext.SaveChangesAsync();
        }
        return sender.Id;
    }
}