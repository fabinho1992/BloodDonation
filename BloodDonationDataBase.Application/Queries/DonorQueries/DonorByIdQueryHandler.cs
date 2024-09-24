using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsAddress;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor;
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
                return ResultViewModel<DonorResponse>.Error($"Donor with ID {request.Id} not found");
            }

            var addressResponse = new AddressResponse(donor.Address.Street, donor.Address.City, donor.Address.State,
                    donor.ZipCode, donor.Address.Complement);
            var donationsList = new List<DonationResponse>();
            foreach (var donation in donor.Donations)
            {
                var newDonation = new DonationResponse(donation.DateDonation, donation.QuantityMl);
                donationsList.Add(newDonation);
            }

            var donorResponse = new DonorResponse(donor.Name, donor.Email, donor.Age, 
                    donor.Gender, donor.Weight, donor.BloodType, donor.FactorRh, addressResponse, donationsList);


            return ResultViewModel<DonorResponse>.Success(donorResponse);
        }
    }
}
