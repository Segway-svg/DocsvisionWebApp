using DocsvisionWebApp;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators;

public class FindCategoryValidator : AbstractValidator<GetEmailRequest>, IGetEmailValidator
{
    public FindCategoryValidator()
    {
        RuleFor(request => request.Name)
            .Cascade(CascadeMode.Continue)
            .NotEmpty()
            .WithMessage("Name is empty")
            .MinimumLength(1)
            .WithMessage("Name is too short")
            .MaximumLength(20)
            .WithMessage("Name is too long");
        RuleFor(request => request.Color)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .IsInEnum();
    }
}