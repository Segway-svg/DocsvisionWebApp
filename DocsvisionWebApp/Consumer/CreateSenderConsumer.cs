using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using DocsvisionWebApp.EntityFramework.Repositories;
using DocsvisionWebApp.Mappers;
using MassTransit;

namespace DocsvisionWebApp.Consumer;

public class CreateSenderConsumer : IConsumer<CreateSenderRequest>
{
    public async Task Consume(ConsumeContext<CreateSenderRequest> context)
    {
        CreateSenderResponse response = new CreateSenderResponse();
        
        SenderRepository repository = new SenderRepository();
        CreateSenderMapper mapper = new CreateSenderMapper();
        
        response.Id = await repository.CreateSenderAsync(mapper.Map(context.Message));
        response.IsSuccess = true;
        response.Errors = new List<string>();
        
        await context.RespondAsync(response);
    }
}