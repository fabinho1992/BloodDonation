using BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands;
using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.IServices;
using BloodDonationDataBase.Domain.Models;
using BloodDonationDataBase.Domain.Models.CepResponse;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Tests.Aplication.Commands
{
    public class CreateDonor
    {
        [Fact]
        public async Task CreateDonor_Return_Ok()
        {
            // Arrange
            var mockRepostory = new Mock<IUnitOfWork>();
            var mockDonorRepository = new Mock<IDonorRepository>();
            var mockAddressRepository = new Mock<IAddressRepository>();
            var mockRepositoryAddress = new Mock<IAddressZipCode>(); // Mock do IAddressZipCode
            var newDonorCommand = new CreateDonorCommand(
                "Fabio", "fabio@gmail.com", new DateTime(1992, 01, 18), Gender.M,
                90, BloodType.A, FactorRh.Positivo, "05820200", "Bl2 Ap52A"
            );

            var expectedZipCode = new ViaCepResponse
            {
                Logradouro = "Rua da Liberdade",
                Localidade = "São Paulo",
                Uf = "SP",
                Cep = "05820200"
            };

            mockRepostory.Setup(x => x.DonorRepository.Create(It.IsAny<Donor>()));
            mockRepositoryAddress.Setup(x => x.SearchZipCode(newDonorCommand.ZipCode).Result).Returns(expectedZipCode);
            mockRepostory.Setup(x => x.AddressRepository.Create(It.IsAny<Address>()));

            var createDonorCommandHandler = new CreateDonorCommandHandler(mockRepostory.Object, mockRepositoryAddress.Object); // Injetar o mock

            // Act
            var result = await createDonorCommandHandler.Handle(newDonorCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            mockRepostory.Verify(x => x.DonorRepository.Create(It.IsAny<Donor>()), Times.Once);
            mockRepostory.Verify(x => x.AddressRepository.Create(It.IsAny<Address>()), Times.Once);
        }
    }
}

