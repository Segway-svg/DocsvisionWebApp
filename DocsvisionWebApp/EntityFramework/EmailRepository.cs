using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework;

public class EmailRepository
{
    public async Task<Guid?> CreateAlbumAsync(DbEmail email)
    {
        using (var dbContext = new EmailDbContext())
        {
            dbContext.Database.Migrate();
            if (dbContext.Senders.ToArray().Length != null)
            {
                foreach (DbSender sender in dbContext.Senders)
                {
                    if (sender.Id == email.SenderId)
                    {
                        dbContext.Emails.Add(email);
                        await dbContext.SaveChangesAsync();
                        return email.Id;
                    }
                }   
            }
        }
        return null;
    }
}