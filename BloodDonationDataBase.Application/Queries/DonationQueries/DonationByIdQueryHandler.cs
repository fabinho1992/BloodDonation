using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonationQueries
{
    public class DonationByIdQueryHandler : IRequestHandler<DonationByIdQuery, ResultViewModel<DonationResponseById>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonationByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<DonationResponseById>> Handle(DonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _unitOfWork.DonationRepository.GetById(request.Id);
            if (donation is null)
            {
                return ResultViewModel<DonationResponseById>.Error($"Donation with ID {request.Id} not found");
            }

            var newDonation = new DonationResponseById(donation.Id, donation.Donor.Name, donation.Donor.Id, donation.Donor.Email,
                donation.Donor.Weight, donation.Donor.BloodType, donation.Donor.FactorRh, donation.DateDonation, donation.QuantityMl);

            return ResultViewModel<DonationResponseById>.Success(newDonation);
        }
    }
}
