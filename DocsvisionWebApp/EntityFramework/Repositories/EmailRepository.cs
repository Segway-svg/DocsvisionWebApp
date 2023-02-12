using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework.Repositories;

public class EmailRepository
{
    public async Task<Guid?> CreateEmailAsync(DbEmail email)
    {
        using (var dbContext = new EmailDbContext())
        {
            dbContext.Database.Migrate();
            
            if (dbContext.Senders.FirstOrDefault(dbS => dbS.Id == email.SenderId) != null &&
                dbContext.Receivers.FirstOrDefault(dbR => dbR.Id == email.ReceiverId) != null)
            {
                dbContext.Emails.Add(email);

                var dbEmailReceiver = new DbEmailReceiver();
                dbEmailReceiver.Id = new Guid();
                dbEmailReceiver.EmailId = email.Id;
                dbEmailReceiver.ReceiverId = email.ReceiverId;
                dbContext.EmailsReceivers.Add(dbEmailReceiver);

                await dbContext.SaveChangesAsync();
            }
            else
            {
                return null;
            }
        }
        return email.Id;
    }
}