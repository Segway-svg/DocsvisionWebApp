using DocsvisionWebApp;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators;

public class CreateEmailValidator : AbstractValidator<CreateEmailRequest>, ICreateEmailValidator
{
    public CreateEmailValidator()
    {
        RuleFor(request => request.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Name is empty")
            .MinimumLength(1)
            .WithMessage("Name is too short")
            .MaximumLength(20)
            .WithMessage("Name is too long");
    }
}