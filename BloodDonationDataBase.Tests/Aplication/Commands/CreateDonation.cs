using BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands;
using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Tests.Aplication.Commands
{
    public class CreateDonation
    {
        [Fact]
        public async Task CreateDonation_Return_Ok()
        {
            // Arrange
            var mockRepository = new Mock<IUnitOfWork>();

            var createCommand = new CreateDonationCommand(1, new DateTime(2024, 09, 26), 400);

            var createDonationCommandHandle = new CreateDonationCommandHandler(mockRepository.Object);
            //Act
            var result = await createDonationCommandHandle.Handle(createCommand, CancellationToken.None);

            //Assert
            mockRepository.Verify(x => x.DonationRepository.Create(It.IsAny<Donation>()), Times.Once);
        }
    }
}
