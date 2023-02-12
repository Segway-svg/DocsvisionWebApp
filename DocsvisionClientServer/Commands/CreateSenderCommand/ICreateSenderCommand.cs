using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;

namespace DocsvisionClientServer.Commands.CreateSenderCommand;

public interface ICreateSenderCommand
{
    public Task<CreateSenderResponse> Execute(CreateSenderRequest request);
}