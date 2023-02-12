using System.Net;
using DocsvisionClientServer.Commands.CreateSenderCommand;
using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DocsvisionClientServer.Controllers;

[ApiController]
[Route("[controller]")]
public class SenderController : ControllerBase
{
    [HttpPost("post")]
    public async Task<CreateSenderResponse> PostSender(
        [FromServices] ICreateSenderCommand command,
        [FromBody] CreateSenderRequest request)
    {
        var response = await command.Execute(request);
        
        HttpContext.Response.StatusCode = response.IsSuccess ? 
            (int)HttpStatusCode.Created : 
            (int)HttpStatusCode.NotFound;

        return response;
    }
}