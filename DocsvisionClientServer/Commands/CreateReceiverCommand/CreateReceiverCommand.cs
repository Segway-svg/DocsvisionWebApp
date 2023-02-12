using DocsvisionClientServer.CategoryRequestValidators.CreateReceiversValidators;
using DocsvisionClientServer.CategoryRequestValidators.CreateSenderValidator;
using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using MassTransit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DocsvisionClientServer.Commands.CreateReceiverCommand;

public class CreateReceiverCommand : ICreateReceiverCommand
{
    private IRequestClient<CreateReceiverRequest> _request;
    private ICreateReceiverValidator _validator;

    public CreateReceiverCommand(ICreateReceiverValidator validator, IRequestClient<CreateReceiverRequest> request)
    {
        _validator = validator;
        _request = request;
    }

    public async Task<CreateReceiverResponse> Execute(CreateReceiverRequest request)
    {
        if (request == null)
        {
            var failureResponse = new CreateReceiverResponse()
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
            var failureResponse = new CreateReceiverResponse()
            {  
                Id = null,
                IsSuccess = false,
                Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList()
            };
            return failureResponse;
        }
        
        var response = await _request.GetResponse<CreateReceiverResponse>(request);
        return response.Message;
    }
}