using DocsvisionWebApp.EntityFramework.Entities;

namespace DocsvisionWebApp.Mappers;

public class CreateEmailMapper
{
    public DbEmail Map(CreateEmailRequest request)
    {
        return new DbEmail()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Receiver = request.Receiver,
            Sender = request.Sender,
            Content = request.Content,
            CreationDate = DateTime.Now
        };
    }
}