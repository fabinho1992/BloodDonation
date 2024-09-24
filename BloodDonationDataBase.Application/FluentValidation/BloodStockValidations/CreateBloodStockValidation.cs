using BloodDonationDataBase.Application.Commands.BloodStockCommands.CreateBloodStockCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.FluentValidation.BloodStockValidations
{
    public class CreateBloodStockValidation : AbstractValidator<CreateBloodStockCommand>
    {
        public CreateBloodStockValidation()
        {
            RuleFor(b => b.BloodType).NotNull()
                .WithMessage("BloodType cannot be null")
                .IsInEnum().WithMessage("0 - A / 1 - B / 2 - AB / 3 - O");

            RuleFor(d => d.FactorRh).NotNull()
                .WithMessage("FactorRh cannot be null")
                .IsInEnum().WithMessage("0 - Positive / 1 - Negative");
        }
    }
}
