using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        IBloodStockRepository BloodStockRepository { get; }
        IDonorRepository DonorRepository { get; }
        IDonationRepository DonationRepository { get; }
        IAddressRepository AddressRepository { get; }
        Task Commit();
    }
}
