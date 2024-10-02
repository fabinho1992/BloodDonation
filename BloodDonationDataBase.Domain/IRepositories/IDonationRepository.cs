using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.IRepositories
{
    public interface IDonationRepository
    {
        Task Create(Donation donation);
        Task<IEnumerable<Donation>> GetAll(ParametrosPaginacao paginacao);
        Task<IEnumerable<Donation>> GetAllReports();
        Task<IEnumerable<Donation>> GetAllBloodType(BloodType bloodType);
        Task<Donation?> GetById(int id);
        Task Delete(Donation donation);
    }
}
