using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Errors
{
    public record Error(string Code, string Message) : IError
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}
