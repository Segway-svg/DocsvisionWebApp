using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;

namespace DocsvisionClientServer.Commands.CreateReceiverCommand;

public interface ICreateReceiverCommand
{
    public Task<CreateReceiverResponse> Execute(CreateReceiverRequest request);
}