using BloodDonationDataBase.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonorCommands.DeleteDonorCommands
{
    public class DeleteDonorCommand : IRequest<ResultViewModel>
    {
        public DeleteDonorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
