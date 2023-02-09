using DocsvisionWebApp.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocsvisionWebApp.EntityFramework;

public class EmailRepository
{
    public async Task<Guid> CreateEmailAsync(DbEmail email)
    {
        using (var dbContext = new EmailDbContext())
        {
            dbContext.Database.Migrate();
            dbContext.Emails.Add(email);
            await dbContext.SaveChangesAsync();
        }
        return email.Id;
    }
}