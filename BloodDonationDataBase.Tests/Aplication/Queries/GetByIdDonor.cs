using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor;
using BloodDonationDataBase.Application.Queries.DonorQueries;
using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Tests.Aplication.Queries
{
    public class GetByIdDonor
    {
        [Fact]
        public async Task GetByIdDonor_Return_Donor()
        {
            //Arrange

            var mockRepository = new Mock<IUnitOfWork>();
            var donorId = 1;
            var donor = new Donor(
                    "Fabio", "fabio@gmail.com", new DateTime(1992, 01, 18), Gender.M, 90, BloodType.A, FactorRh.Positivo, "05820200"
                );
            donor.Id = donorId;

            mockRepository.Setup(x => x.DonorRepository.GetById(donor.Id));

            var donorQuery = new DonorByIdQuery(donorId);
            var handler = new DonorByIdQueryHandler(mockRepository.Object);

            //Act

            var result = await handler.Handle(donorQuery, CancellationToken.None);

            //Assert

            Assert.NotNull(result);
            Assert.IsType<ResultViewModel<DonorResponse>>(result);
            mockRepository.Verify(x => x.DonorRepository.GetById(donor.Id), Times.Once);
        }
    }
}
