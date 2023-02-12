using DocsvisionClientServer.CategoryRequestValidators;
using DocsvisionClientServer.CategoryRequestValidators.CreateEmailValidator;
using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using MassTransit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DocsvisionClientServer.Commands.CreateEmailCommand;


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
            var failureResponse = new CreateEmailResponse()
            {
                Id = null,
                IsSuccess = false,
                Errors = new List<string>()
            };
            failureResponse.Errors.Add("Request is empty");
            return failureResponse;
        }

        ValidationResult validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var failureResponse = new CreateEmailResponse()
            {  
                Id = null,
                IsSuccess = false,
                Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList()
            };
            return failureResponse;
        }
        
        var response = await _request.GetResponse<CreateEmailResponse>(request);

        if (response.Message.Id == null)
        {
            var failureResponse = new CreateEmailResponse()
            {
                Id = null,
                IsSuccess = false,
                Errors = new List<string>()
            };
            failureResponse.Errors.Add("There is not such Receiver or Sender");
            return failureResponse;
        }
        
        return response.Message;
    }
}