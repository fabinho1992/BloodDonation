using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonorCommands.DeleteDonorCommands
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel>
    { 
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDonorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _unitOfWork.DonorRepository.GetById(request.Id);
            if (donor is null)
            {
                return ResultViewModel.Error("Donor not found");
            }

            await _unitOfWork.DonorRepository.Delete(donor);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();
        }
    }
}
