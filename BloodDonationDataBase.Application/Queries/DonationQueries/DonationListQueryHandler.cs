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
    public class DonationListQueryHandler : IRequestHandler<DonationListQuery, ResultViewModel<List<DonationResponseToList>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonationListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<DonationResponseToList>>> Handle(DonationListQuery request, CancellationToken cancellationToken)
        {
            var listDonations = await _unitOfWork.DonationRepository.GetAll(request);
            if (listDonations is null)
            {
                return ResultViewModel<List<DonationResponseToList>>.Error("Donations not found");
            }

            var newDonations = new List<DonationResponseToList>();

            foreach (var donation in listDonations) 
            {
                var newDonation = new DonationResponseToList(donation.Id, donation.Donor.Id, donation.Donor.Name, donation.Donor.Email,
                    donation.DateDonation, donation.QuantityMl);
                newDonations.Add(newDonation);
            }

            return ResultViewModel<List<DonationResponseToList>>.Success(newDonations);

        }
    }
}
