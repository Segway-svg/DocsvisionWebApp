using DocsvisionClientServer.Requests;
using FluentValidation;

namespace DocsvisionClientServer.CategoryRequestValidators.CreateEmailValidator;

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
        RuleFor(request => request.SenderId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("SenderId is null");
        RuleFor(request => request.ReceiverId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("ReceiverId is null");
        RuleFor(request => request.Content)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(50)
            .WithMessage("Content is too long");
    }
}