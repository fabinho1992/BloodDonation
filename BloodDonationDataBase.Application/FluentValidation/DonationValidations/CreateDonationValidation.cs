using BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.FluentValidation.DonationValidations
{
    public class CreateDonationValidation : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationValidation()
        {
            RuleFor(d => d.DonorId).NotNull()
                .WithMessage("DonorId is required")
                .GreaterThan(0)
                .WithMessage("DonorId must be a positive number");

            RuleFor(d => d.QuantityMl).NotNull().NotEmpty()
                .WithMessage("Donation cannot be null")
                .InclusiveBetween(420, 470)
                .WithMessage("Donation must be between {From} and {To} ml");

            
        }
    }
}
