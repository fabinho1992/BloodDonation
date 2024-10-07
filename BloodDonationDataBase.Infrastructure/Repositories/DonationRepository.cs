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
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodDataBaseDbContext _dbContext;

        public DonationRepository(BloodDataBaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Donation donation)
        {
            await _dbContext.Donations.AddAsync(donation);
        }

        public async Task Delete(Donation user)
        {
            var donation = await GetById(user.Id);
            _dbContext.Donations.Remove(donation);
        }

        public async Task<IEnumerable<Donation>> GetAll(ParametrosPaginacao paginacao)
        {
            return await _dbContext.Donations.Include(x => x.Donor).OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<IEnumerable<Donation>> GetAllBloodType(BloodType bloodType)
        {
            return await _dbContext.Donations.Include(a => a.Donor).Where
                (b => b.Donor.BloodType == bloodType).ToListAsync();
                
        }

        public async Task<IEnumerable<Donation>> GetAllReports()
        {
            return await _dbContext.Donations.ToListAsync();
        }

        public async Task<IEnumerable<Donation>> GetAllThirtyDays()
        {
            return await _dbContext.Donations.Include(d => d.Donor).
                Where(d => d.DateDonation >= DateTime.Now.AddDays(-30))
                .ToListAsync();
        
        }

        public async Task<Donation?> GetById(int id)
        {
            var Donor = await _dbContext.Donations.Include(a => a.Donor)
                .SingleOrDefaultAsync(a => a.Id == id);
            return Donor;
        }

    }
}
