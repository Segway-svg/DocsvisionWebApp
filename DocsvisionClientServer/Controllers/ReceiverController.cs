using System.Net;
using DocsvisionClientServer.Commands.CreateReceiverCommand;
using DocsvisionClientServer.Commands.CreateSenderCommand;
using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DocsvisionClientServer.Controllers;

[ApiController]
[Route("[controller]")]
public class ReceiverController : ControllerBase
{
    [HttpPost("post")]
    public async Task<CreateReceiverResponse> PostReceiver(
        [FromServices] ICreateReceiverCommand command,
        [FromBody] CreateReceiverRequest request)
    {
        var response = await command.Execute(request);
        
        HttpContext.Response.StatusCode = response.IsSuccess ? 
            (int)HttpStatusCode.Created : 
            (int)HttpStatusCode.NotFound;

        return response;
    }
}