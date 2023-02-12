using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;

namespace DocsvisionClientServer.Commands.CreateEmailCommand;

public interface ICreateEmailCommand
{
    public Task<CreateEmailResponse> Execute(CreateEmailRequest request);

}