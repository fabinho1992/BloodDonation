using BloodDonationDataBase.Application.Services;
using BloodDonationDataBase.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Infrastructure.Services
{
    public class AddressZipCode : IAddressZipCode
    {
        public async Task<Address> SearchZipCode(string zipCode)
        {
            using var client = new HttpClient();
            var url = $"https://viacep.com.br/ws/{zipCode}/json/";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(json);
            }
            else
            {
                return null;
            }
        }
    }
}
