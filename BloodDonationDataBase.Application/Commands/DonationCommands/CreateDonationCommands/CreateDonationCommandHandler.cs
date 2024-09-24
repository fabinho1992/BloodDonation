using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDonationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            
            var donation = new Donation(request.DonorId, request.DateDonation, request.QuantityMl);
            await _unitOfWork.DonationRepository.Create(donation);
            var donor = await _unitOfWork.DonorRepository.GetById(donation.DonorId);
            donor.LastDonationDate();
            var bloodStock = await _unitOfWork.BloodStockRepository.GetBloodType(donor.BloodType, donor.FactorRh);
            bloodStock.ReceivingDonation(donation.QuantityMl);
            
            await _unitOfWork.Commit();

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
