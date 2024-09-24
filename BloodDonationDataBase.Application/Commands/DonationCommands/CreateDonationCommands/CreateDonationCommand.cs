using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands
{
    public class CreateDonationCommand : IRequest<ResultViewModel<int>>
    {
        public CreateDonationCommand(int donorId, DateTime dateDonation, int quantityMl)
        {
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
        }

        public int DonorId { get; private set; }
        public DateTime DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
