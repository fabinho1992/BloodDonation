using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using BloodDonationDataBase.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {   
        private readonly BloodDataBaseDbContext _dbContext;

        public AddressRepository(BloodDataBaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Address address)
        {
            await _dbContext.AddAsync(address);
        }
    }
}
