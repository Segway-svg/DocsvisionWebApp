using DocsvisionClientServer.CategoryRequestValidators;
using DocsvisionWebApp;
using MassTransit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DocsvisionClientServer.Commands;

public class GetEmailCommand : IGetEmailCommand
{
    private IRequestClient<GetEmailRequest> _request;
    private IGetEmailValidator _validator;

    public GetEmailCommand(IGetEmailValidator validator, IRequestClient<GetEmailRequest> request)
    {
        _validator = validator;
        _request = request;
    }
    
    public async Task<GetEmailResponse> Execute(GetEmailRequest request)
    {
        if (request == null)
        {
            var message = "Request is empty";
            var failureResponse = new GetEmailResponse()
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
            var failureResponse = new GetEmailResponse()
            {
                IsSuccess = false,
                Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList()
            };
            return failureResponse;
        }

        var response = await _request.GetResponse<GetEmailResponse>(request);
        return response.Message;
    }
}