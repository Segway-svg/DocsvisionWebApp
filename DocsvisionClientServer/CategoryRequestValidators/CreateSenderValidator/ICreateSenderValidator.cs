using DocsvisionClientServer.Requests;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators.CreateSenderValidator;

public interface ICreateSenderValidator : IValidator<CreateSenderRequest>
{
    
}