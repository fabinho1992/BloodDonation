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
    public class DonationBloodTypeQueryHandler : IRequestHandler<DonationBloodTypeQuery, ResultViewModel<List<DonationResponseToList>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonationBloodTypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<DonationResponseToList>>> Handle(DonationBloodTypeQuery request, CancellationToken cancellationToken)
        {
            var donations = await _unitOfWork.DonationRepository.GetAllBloodType(request.BloodType);
            if (!donations.Any())
            {
                return ResultViewModel<List<DonationResponseToList>>.Error("Donations not found");
            }

            var donationsResponse = new List<DonationResponseToList>();
            foreach (var donation in donations) 
            {
                var newDonation = new DonationResponseToList(donation.Id, donation.Donor.Id, donation.Donor.Name,
                    donation.Donor.Email, donation.DateDonation, donation.QuantityMl);
                donationsResponse.Add(newDonation);
            }

            return ResultViewModel<List<DonationResponseToList>>.Success(donationsResponse);
        }
    }
}
