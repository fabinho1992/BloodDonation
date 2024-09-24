using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation
{
    public class DonationResponse
    {
        public DonationResponse(DateTime dateDonation, int quantityMl)
        {
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
        }

        public DateTime DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
