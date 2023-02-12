using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using DocsvisionWebApp.EntityFramework.Repositories;
using DocsvisionWebApp.Mappers;
using MassTransit;

namespace DocsvisionWebApp.Consumer;

public class CreateReceiverConsumer : IConsumer<CreateReceiverRequest>
{
    public async Task Consume(ConsumeContext<CreateReceiverRequest> context)
    {
        CreateReceiverResponse response = new CreateReceiverResponse();
        
        ReceiverRepository repository = new ReceiverRepository();
        CreateReceiverMapper mapper = new CreateReceiverMapper();
        
        response.Id = await repository.CreateReceiverAsync(mapper.Map(context.Message));
        response.IsSuccess = true;
        response.Errors = new List<string>();
        
        await context.RespondAsync(response);
    }
}