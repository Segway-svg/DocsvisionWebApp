using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using DocsvisionWebApp.EntityFramework;
using DocsvisionWebApp.Mappers;
using MassTransit;

namespace DocsvisionWebApp;

public class CreateEmailConsumer : IConsumer<CreateEmailRequest>
{
    public async Task Consume(ConsumeContext<CreateEmailRequest> context)
    {
        CreateEmailResponse response = new CreateEmailResponse();
        
        EmailRepository repository = new EmailRepository();
        CreateEmailMapper mapper = new CreateEmailMapper();
        
        response.Id = await repository.CreateAlbumAsync(mapper.Map(context.Message));
        await context.RespondAsync(response);
    }
}