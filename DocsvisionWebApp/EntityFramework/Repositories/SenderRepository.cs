using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework.Repositories;

public class SenderRepository
{
    public async Task<Guid?> CreateSenderAsync(DbSender receiver)
    {
        using (var dbContext = new EmailDbContext())
        {
            dbContext.Database.Migrate();
            dbContext.Senders.Add(receiver);
            await dbContext.SaveChangesAsync();
        }
        return receiver.Id;
    }
}