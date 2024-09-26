using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation
{
    public class DonationResponseToList
    {
        public DonationResponseToList(int idDonation, int donorId,string donorName, string donorEmail, DateTime dateDonation, int quantityMl)
        {
            IdDonation = idDonation;
            DonorId = donorId;
            DonorName = donorName;
            DonorEmail = donorEmail;
            DateDonation = dateDonation.ToString("dd/MM/yyyy");
            QuantityMl = quantityMl;
        }

        public int IdDonation { get; private set; }
        public int DonorId { get; private set; }
        public string DonorName { get; private set; }
        public string DonorEmail { get; private set; }
        public string DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
