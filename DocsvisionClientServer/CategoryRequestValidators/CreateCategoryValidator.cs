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
        RuleFor(request => request.Receiver)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Receiver's name is empty")
            .MinimumLength(1)
            .WithMessage("Receiver's name is too short")
            .MaximumLength(20)
            .WithMessage("Receiver's name is too long");
        RuleFor(request => request.Sender)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Sender's name is empty")
            .MinimumLength(1)
            .WithMessage("Sender's name is too short")
            .MaximumLength(20)
            .WithMessage("Sender's name is too long");
        RuleFor(request => request.Content)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(255)
            .WithMessage("Sender's name is too long");
    }
}