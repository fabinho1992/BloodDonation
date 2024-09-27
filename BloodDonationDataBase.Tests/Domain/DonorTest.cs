using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Tests.Domain
{
    public class DonorTest
    {
        [Fact]
        public void CreateDonor_return_CorrectAge()
        {
            //Arrange
            var donor = new Donor(
                    "Fabio","fabio@gmail.com", new DateTime(1992,01,18), Gender.M, 90, BloodType.A, FactorRh.Positivo, "05820200"
                );

            //Act
            //Assert
            //Testando se o metodo de calcular idade esta sendo chamado no criação do Donor
            Assert.Equal(32, donor.Age);
        }

        
    }
}
