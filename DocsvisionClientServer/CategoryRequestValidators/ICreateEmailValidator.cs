using DocsvisionWebApp;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators;

public interface ICreateEmailValidator : IValidator<CreateEmailRequest>
{
    
}