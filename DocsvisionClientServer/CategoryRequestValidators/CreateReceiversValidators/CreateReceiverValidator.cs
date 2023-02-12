using DocsvisionClientServer.Requests;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators.CreateReceiversValidators;

public class CreateReceiverValidator : AbstractValidator<CreateReceiverRequest>, ICreateReceiverValidator
{
    public CreateReceiverValidator()
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