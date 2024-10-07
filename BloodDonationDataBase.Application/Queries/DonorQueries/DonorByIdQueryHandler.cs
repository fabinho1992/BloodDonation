using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsAddress;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor;
using BloodDonationDataBase.Application.Logs;
using BloodDonationDataBase.Domain.Errors;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonorQueries
{
    public class DonorByIdQueryHandler : IRequestHandler<DonorByIdQuery, ResultViewModel<DonorResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<DonorResponse>> Handle(DonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _unitOfWork.DonorRepository.GetById(request.Id);
            if (donor is null)
            {
                Log.LogToFile("Donor null", DonorErrors.Notfound.ToString());
                return ResultViewModel<DonorResponse>.Error(DonorErrors.Notfound.ToString());
            }

            var addressResponse = new AddressResponse(donor.Address.Street, donor.Address.City, donor.Address.State,
                    donor.ZipCode, donor.Address.Complement);
            var donationsList = new List<DonationResponseToDonor>();
            foreach (var donation in donor.Donations)
            {
                var newDonation = new DonationResponseToDonor(donation.DateDonation, donation.QuantityMl);
                donationsList.Add(newDonation);
            }

            var donorResponse = new DonorResponse(donor.Name, donor.Email, donor.Age, 
                    donor.Gender, donor.Weight, donor.BloodType, donor.FactorRh, donor.LastDonation, addressResponse, donationsList);


            return ResultViewModel<DonorResponse>.Success(donorResponse);
        }
    }
}
