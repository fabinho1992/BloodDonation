using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Donor
    {
        public int Id { get; private set; }
        public int Name { get; private set; }
        public string Email { get; private set; }
        public int MyProperty { get; set; }
    }
}
