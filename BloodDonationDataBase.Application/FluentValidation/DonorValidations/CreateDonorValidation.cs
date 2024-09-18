using BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands;
using FluentValidation;
using System.Data;

namespace BloodDonationDataBase.Application.FluentValidation.DonorValidations
{
    public class CreateDonorValidation : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidation()
        {
            RuleFor(d => d.Name).NotEmpty().NotNull()
                .WithMessage("Name cannot be null")
                .MaximumLength(50).WithMessage("Must contain a maximum of 50 characters")
                .MinimumLength(3).WithMessage("Must contain a minimum of 3 characters");

            RuleFor(d => d.Email).NotNull()
                .WithMessage("Email cannot be null")
                .EmailAddress().WithMessage("Insert a email valid ");

            RuleFor(d => d.DateOfBirth).NotNull()
                .WithMessage("DateOfBirth cannot be null")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date of birth must be less than or equal to the current date.");

            RuleFor(d => d.Gender).NotEmpty()
                .WithMessage("Gender cannot be null")
                .IsInEnum().WithMessage(" 0 - M / 1 - F (M = Masculine / F = Feminine)");

            RuleFor(d => d.Weight)
                .GreaterThan(0)
                .WithMessage("Weight must be a positive number")
                .InclusiveBetween(50, 200)
                .WithMessage("Weight must be between {From} and {To} kg");
        }
    }
}
