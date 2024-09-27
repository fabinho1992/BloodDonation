using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Tests.Domain
{
    public class BloodStockTests
    {
        [Fact]
        public void BloodStockReceivingDonation_return_Made()
        {
            //Arrange
            var newBloodStock = new BloodStock(
                bloodType: BloodType.A,
                factorRh: FactorRh.Positivo
                );

            //Act

            newBloodStock.ReceivingDonation(100);
            //Assert

            Assert.NotNull( newBloodStock );
            Assert.Equal(100, newBloodStock.QuantityMl);
        }

        [Fact]
        public void BloodStockWithDrawal_Return_BloodWithDrawal()
        {
            //Arrange
            var newBloodStock = new BloodStock(
                bloodType: BloodType.A,
                factorRh: FactorRh.Positivo
                );

            //Act

            newBloodStock.ReceivingDonation(100);
            newBloodStock.BloodWithdrawal(50);
            //Assert

            Assert.NotNull(newBloodStock);
            Assert.Equal(50, newBloodStock.QuantityMl);
        }
    }
}
