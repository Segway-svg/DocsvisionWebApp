using DocsvisionWebApp;

namespace DocsvisionClientServer.Commands;

public interface ICreateEmailCommand
{
    public Task<CreateEmailResponse> Execute(CreateEmailRequest request);

}