using BloodDonationDataBase.Domain.Enuns;
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
    public class BloodStockRepositoy : IBloodStockRepository
    {
        private readonly BloodDataBaseDbContext _DbConext;

        public BloodStockRepositoy(BloodDataBaseDbContext dbConext)
        {
            _DbConext = dbConext;
        }

        public async Task Create(BloodStock bloodStock)
        {
            await _DbConext.BloodStocks.AddAsync(bloodStock);
        }

        public async Task<IEnumerable<BloodStock>> GetAll()
        {
            return await _DbConext.BloodStocks.AsNoTracking().ToListAsync();
        }

        public async Task<BloodStock?> GetBloodType(BloodType bloodType, FactorRh factorRh)
        {
            var donors = await _DbConext.BloodStocks.Where(e => e.BloodType == bloodType && e.FactorRh == factorRh)
                .FirstOrDefaultAsync();
                            
            return donors;
        }
    }
}
