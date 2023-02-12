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

        if (response.Id == null)
        {
            response.Id = null;
            response.IsSuccess = false;
            response.Errors = new List<string>();
            response.Errors.Add("There is not such Receiver");
        }
        else
        {
            response.Id = Guid.NewGuid();
            response.IsSuccess = true;
            response.Errors = new List<string>();
        }
        
        await context.RespondAsync(response);
    }
}