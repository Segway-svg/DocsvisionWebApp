using System.Net;
using DocsvisionClientServer.Commands.CreateEmailCommand;
using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace DocsvisionClientServer.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    [HttpPost("post")]
    public async Task<CreateEmailResponse> PostGroup(
        [FromServices] ICreateEmailCommand command,
        [FromBody] CreateEmailRequest request)
    {
        var response = await command.Execute(request);
        
        HttpContext.Response.StatusCode = response.IsSuccess ? 
            (int)HttpStatusCode.Created : 
            (int)HttpStatusCode.NotFound;

        return response;
    }
}