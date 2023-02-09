using DocsvisionWebApp;

namespace DocsvisionClientServer.Commands;

public interface IGetEmailCommand
{
    public Task<GetEmailResponse> Execute(GetEmailRequest request);
}