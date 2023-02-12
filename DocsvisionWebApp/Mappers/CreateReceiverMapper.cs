using DocsvisionClientServer.Requests;
using DocsvisionWebApp.EntityFramework.Entities;

namespace DocsvisionWebApp.Mappers;

public class CreateReceiverMapper
{
    public DbReceiver Map(CreateReceiverRequest request)
    {
        return new DbReceiver()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
    }
}