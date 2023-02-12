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
            
            if (dbContext.Senders.FirstOrDefault(dbS => dbS.Id == email.SenderId) != null)
            {
                dbContext.Emails.Add(email);
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