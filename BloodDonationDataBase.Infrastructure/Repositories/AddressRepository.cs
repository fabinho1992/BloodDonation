using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using BloodDonationDataBase.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
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
            await _dbContext.Addresses.AddAsync(address);
        }

        public async Task<Address?> GetById(int id)
        {
            return await _dbContext.Addresses.SingleOrDefaultAsync(x => x.DonorId == id);
        }

        public async Task Update(Address address)
        {
            _dbContext.Addresses.Update(address);
        }
    }
}
