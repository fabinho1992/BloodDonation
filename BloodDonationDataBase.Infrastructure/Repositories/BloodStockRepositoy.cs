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

        public async Task<IEnumerable<BloodStock>> GetAll(ParametrosPaginacao paginacao)
        {
            return await _DbConext.BloodStocks.AsNoTracking().OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<BloodStock?> GetBloodType(BloodType bloodType)
        {
            var donors = await _DbConext.BloodStocks.SingleOrDefaultAsync(b => b.BloodType == bloodType);

            return donors;
        }
    }
}
