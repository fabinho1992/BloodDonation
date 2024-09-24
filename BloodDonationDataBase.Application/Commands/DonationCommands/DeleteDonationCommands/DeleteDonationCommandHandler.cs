using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonationCommands.DeleteDonationCommands
{
    public class DeleteDonationCommandHandler : IRequestHandler<DeleteDonationCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDonationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _unitOfWork.DonationRepository.GetById(request.Id);
            if (donation == null) 
            {
                return ResultViewModel.Error("Donation not found");
            }

            await _unitOfWork.DonationRepository.Delete(donation);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();
        }
    }
}
