using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace DocsvisionClientServer.Controllers;

[ApiController]
[Route("[controller]")]
public class SenderController : ControllerBase
{
    [HttpPost("post")]
    public async Task<CreateSenderResponse> PostGroup(
        [FromServices] IRequestClient<CreateSenderRequest> requestClient,
        [FromBody] CreateSenderRequest request)
    {
        var response = await requestClient.GetResponse<CreateSenderResponse>(request);
        return response.Message;
    }
}