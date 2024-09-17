using BloodDonationDataBase.Application.Dtos.CepResponse;
using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Services
{
    public interface IAddressZipCode
    {
        Task<ViaCepResponse> SearchZipCode(string zipCode);
    }
}
