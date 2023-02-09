using DocsvisionClientServer.CategoryRequestValidators;
using DocsvisionWebApp;
using MassTransit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DocsvisionClientServer.Commands;


public class CreateEmailCommand : ICreateEmailCommand
{
    private IRequestClient<CreateEmailRequest> _request;
    private ICreateEmailValidator _validator;

    public CreateEmailCommand(ICreateEmailValidator validator, IRequestClient<CreateEmailRequest> request)
    {
        _validator = validator;
        _request = request;
    }

    public async Task<CreateEmailResponse> Execute(CreateEmailRequest request)
    {
        if (request == null)
        {
            var message = "Request is empty";
            var failureResponse = new CreateEmailResponse()
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
            var failureResponse = new CreateEmailResponse()
            {  
                IsSuccess = false,
                Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList()
            };
            return failureResponse;
        }
        
        var response = await _request.GetResponse<CreateEmailResponse>(request);
        return response.Message;
    }
}