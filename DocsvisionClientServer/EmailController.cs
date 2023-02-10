using DocsvisionWebApp;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace DocsvisionClientServer;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    [HttpPost("post")]
    public async Task<CreateEmailResponse> PostGroup(
        [FromServices] IRequestClient<CreateEmailRequest> requestClient,
        [FromBody] CreateEmailRequest request)
    {
        var response = await requestClient.GetResponse<CreateEmailResponse>(request);
        return response.Message;
    }
}