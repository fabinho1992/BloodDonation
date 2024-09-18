using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.IRepositories
{
    public interface IAddressRepository
    {
        Task Create(Address address);
        Task<Address?> GetById(int id);
        Task Update(Address address);
    }
}
