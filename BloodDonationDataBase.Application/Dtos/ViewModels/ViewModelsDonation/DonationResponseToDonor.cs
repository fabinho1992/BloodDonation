using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation
{
    public class DonationResponseToDonor
    {
        public DonationResponseToDonor(DateTime dateDonation, int quantityMl)
        {
            DateDonation = dateDonation.ToString("dd/MM/yyyy");
            QuantityMl = quantityMl;
        }

        public string DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
