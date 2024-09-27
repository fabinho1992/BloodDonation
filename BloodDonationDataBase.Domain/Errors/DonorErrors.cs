using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Errors
{
    public class DonorErrors
    {
        public static readonly Error Notfound = new(
            "Donor.NotFound", "The Donor could not be found");
    }
}
