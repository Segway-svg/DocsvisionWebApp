using DocsvisionClientServer.Requests;
using DocsvisionWebApp.EntityFramework.Entities;

namespace DocsvisionWebApp.Mappers;

public class CreateSenderMapper
{
    public DbSender Map(CreateSenderRequest request)
    {
        return new DbSender()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
    }
}