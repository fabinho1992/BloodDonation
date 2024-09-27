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
            var mockDonatinoRepository = new Mock<IDonationRepository>();
            var mockBloodStockRepository = new Mock<IBloodStockRepository>();
            var mockDonorRepository = new Mock<IDonorRepository>();

            var createCommand = new CreateDonationCommand(1, new DateTime(2024, 09, 26), 400);
            var donor = new Donor(
                "Fabio", "fabio@gmail.com", new DateTime(1992, 01, 18), Gender.M, 90, BloodType.A,
                
                FactorRh.Positivo, "05820200"
            );
            donor.Id = 1;
            var bloodStock = new BloodStock(BloodType.A, FactorRh.Positivo);

            mockRepository.Setup(x => x.DonationRepository.Create(It.IsAny<Donation>()));
            mockRepository.Setup(x => x.DonorRepository.GetById(createCommand.DonorId).Result).Returns(donor); // Retorna o donor
            donor.LastDonationDate();
            mockRepository.Setup(x => x.BloodStockRepository.GetBloodType(BloodType.A, FactorRh.Positivo).Result)
                .Returns(bloodStock); 

            var createDonationCommandHandle = new CreateDonationCommandHandler(mockRepository.Object);
            //Act
            var result = await createDonationCommandHandle.Handle(createCommand, CancellationToken.None);

            //Assert
            mockRepository.Verify(x => x.DonationRepository.Create(It.IsAny<Donation>()), Times.Once);
            mockRepository.Verify(x => x.DonorRepository.GetById(createCommand.DonorId), Times.Once);
            mockRepository.Verify(x => x.BloodStockRepository.GetBloodType(bloodStock.BloodType,
                bloodStock.FactorRh), Times.Once);
        }
    }
    
}
