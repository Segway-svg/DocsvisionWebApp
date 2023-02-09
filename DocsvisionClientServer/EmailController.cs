using System.Net;
using DocsvisionClientServer.Commands;
using DocsvisionWebApp;
using Microsoft.AspNetCore.Mvc;

namespace DocsvisionClientServer;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    [HttpPost("create")]
    public async Task<CreateEmailResponse> CreateEmailController(
        [FromServices] ICreateEmailCommand command,
        [FromBody] CreateEmailRequest request)
    {
        var response = await command.Execute(request);

        HttpContext.Response.StatusCode =
            response.IsSuccess ? (int)HttpStatusCode.Created : (int)HttpStatusCode.NotFound;

        return response;
    }
}