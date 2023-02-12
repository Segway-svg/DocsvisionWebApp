using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework.Repositories;

public class ReceiverRepository
{
    public async Task<Guid?> CreateReceiverAsync(DbReceiver receiver)
    {
        using (var dbContext = new EmailDbContext())
        {
            dbContext.Database.Migrate();
            dbContext.Receivers.Add(receiver);
            await dbContext.SaveChangesAsync();
        }
        return receiver.Id;
    }
}