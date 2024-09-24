using BloodDonationDataBase.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonationCommands.DeleteDonationCommands
{
    public class DeleteDonationCommand : IRequest<ResultViewModel>
    {
        public DeleteDonationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
