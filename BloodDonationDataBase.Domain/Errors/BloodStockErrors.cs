using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodDonationDataBase.Domain.Errors
{
    public class BloodStockErrors
    {
        public static readonly Error NotFound = new(
           "BloodStock.NotFound", "The BloodStock could not be found");

        public static readonly Error NotEnoughAmount = new(
                "BloodStock.NotEnoughAmount", "There isn't enough amount to consume.");
    }
}
