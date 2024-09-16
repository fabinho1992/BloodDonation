using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.IRepositories
{
    public interface IDonorRepository
    {
        Task Create(Donor donor);
        Task<IEnumerable<Donor>> GetAll(ParametrosPaginacao paginacao);
        Task<IEnumerable<Donation>> GetAllBloodType(BloodType bloodType);
        Task<Donor> GetById(int id);
        Task Delete(Donor user);
    }
}
