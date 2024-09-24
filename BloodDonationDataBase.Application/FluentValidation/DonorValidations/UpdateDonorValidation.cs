using BloodDonationDataBase.Application.Commands.DonorCommands.UpdateDonorCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.FluentValidation.DonorValidations
{
    public class UpdateDonorValidation : AbstractValidator<UpdateDonorCommand>
    {
        public UpdateDonorValidation()
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

            RuleFor(d => d.BloodType).NotEmpty()
                .WithMessage("BloodType cannot be null")
                .IsInEnum().WithMessage("0 - A / 1 - B / 2 - AB / 3 - O");

            RuleFor(d => d.FactorRh).NotEmpty()
                .WithMessage("FactorRh cannot be null")
                .IsInEnum().WithMessage("0 - Positive / 1 - Negative");

            RuleFor(d => d.ZipCode).NotEmpty().NotNull()
                .WithMessage("ZipCode cannot be null")
                .MaximumLength(8).WithMessage("Must contain a maximum of 8 characters");

            RuleFor(d => d.Complement).NotNull().NotEmpty()
                .WithMessage("Complement cannot be null")
                .MaximumLength(50).WithMessage("Must contain a maximum of 50 characteres");
        }
    }
}
