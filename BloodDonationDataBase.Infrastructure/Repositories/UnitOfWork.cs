using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDonationRepository? _donationRepository;
        private IDonorRepository? _donorRepository;
        private IBloodStockRepository? _bloodStockRepository;
        private IAddressRepository? _addressRepository;


        private readonly BloodDataBaseDbContext _db;

        public UnitOfWork(BloodDataBaseDbContext db)
        {
            _db = db;
        }

        public IBloodStockRepository BloodStockRepository
        {
            get
            {
                return _bloodStockRepository = _bloodStockRepository ?? new BloodStockRepositoy(_db);
            }
        }

        public IDonorRepository DonorRepository
        {
            get
            {
                return _donorRepository = _donorRepository ?? new DonorRepository(_db);
            }
        }

        public IDonationRepository DonationRepository
        {
            get
            {
                return _donationRepository = _donationRepository ?? new DonationRepository(_db);
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                return _addressRepository = _addressRepository ?? new AddressRepository(_db);
            }
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _db.DisposeAsync();
        }
    }
}
