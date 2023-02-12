using DocsvisionClientServer.CategoryRequestValidators;
using DocsvisionClientServer.CategoryRequestValidators.CreateSenderValidator;
using DocsvisionClientServer.Commands.CreateEmailCommand;
using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using MassTransit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DocsvisionClientServer.Commands.CreateSenderCommand;


public class CreateSenderCommand : ICreateSenderCommand
{
    private IRequestClient<CreateSenderRequest> _request;
    private ICreateSenderValidator _validator;

    public CreateSenderCommand(ICreateSenderValidator validator, IRequestClient<CreateSenderRequest> request)
    {
        _validator = validator;
        _request = request;
    }

    public async Task<CreateSenderResponse> Execute(CreateSenderRequest request)
    {
        if (request == null)
        {
            var message = "Request is empty";
            var failureResponse = new CreateSenderResponse()
            {
                IsSuccess = false,
                Errors = new List<string>()
            };
            failureResponse.Errors.Add(message);
            return failureResponse;
        }

        ValidationResult validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var failureResponse = new CreateSenderResponse()
            {  
                IsSuccess = false,
                Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList()
            };
            return failureResponse;
        }
        
        var response = await _request.GetResponse<CreateSenderResponse>(request);
        return response.Message;
    }
}