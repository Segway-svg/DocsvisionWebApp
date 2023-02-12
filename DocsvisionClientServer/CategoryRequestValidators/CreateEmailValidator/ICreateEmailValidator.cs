using DocsvisionClientServer.Requests;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators.CreateEmailValidator;

public interface ICreateEmailValidator : IValidator<CreateEmailRequest>
{
    
}