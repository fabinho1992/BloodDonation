using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.IRepositories
{
    public interface IBloodStockRepository
    {
        Task Create(BloodStock bloodStock);
        Task<IEnumerable<BloodStock>> GetAll();
        Task<BloodStock?> GetBloodType(BloodType bloodType, FactorRh factorRh);
    }
}
