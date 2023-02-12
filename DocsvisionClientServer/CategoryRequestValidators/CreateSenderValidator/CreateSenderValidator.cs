using DocsvisionClientServer.CategoryRequestValidators.CreateEmailValidator;
using DocsvisionClientServer.Requests;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators.CreateSenderValidator;

public class CreateSenderValidator : AbstractValidator<CreateSenderRequest>, ICreateSenderValidator
{
    public CreateSenderValidator()
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