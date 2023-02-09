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

        response.Id = await repository.CreateEmailAsync(mapper.Map(context.Message));
        response.IsSuccess = true;
        response.Errors = new List<string>();
        
        await context.RespondAsync(response);
    }
}