using Application.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators;

public sealed class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
    {
        RuleFor(h => h.Hotel.Name).NotEmpty().MaximumLength(50);
        RuleFor(h => h.Hotel.Description).NotEmpty().MaximumLength(3000);
    }

    public override ValidationResult Validate(ValidationContext<CreateHotelCommand> context)
    {
        return context.InstanceToValidate.Hotel is null
            ? new ValidationResult(new[] { new ValidationFailure("HotelForCreationDto", "HotelForCreationDto object is null") })
        : base.Validate(context);
    }
}