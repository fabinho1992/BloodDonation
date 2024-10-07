using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using BloodDonationDataBase.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationDataBase.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodDataBaseDbContext _dbContext;

        public DonorRepository(BloodDataBaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Donor donor)
        {
            await _dbContext.Donors.AddAsync(donor);
        }

        public async Task Delete(Donor donor)
        {
            var donorDelete = await GetById(donor.Id);
            _dbContext.Donors.Remove(donorDelete);
        }

        public async Task<IEnumerable<Donor>> GetAll(ParametrosPaginacao paginacao)
        {
            return await _dbContext.Donors.AsNoTracking().OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<Donor> GetById(int id)
        {
            var donor = await _dbContext.Donors.Include(d => d.Address)
                .Include(d => d.Donations).SingleOrDefaultAsync(d => d.Id == id);

            return donor;
        }

        public async Task Update(Donor donor)
        {
             _dbContext.Donors.Update(donor);
        }

        public async Task<IEnumerable<Donor>> GetAllBloodType(BloodType bloodType)
        {
            var donors = await _dbContext.Donors.Include(d => d.Address)
                .Include(d => d.Donations).Where(d => d.BloodType == bloodType).ToListAsync();

            return donors;
        }

        public async Task<IEnumerable<Donor>> GetAllReport()
        {
            return await _dbContext.Donors.AsNoTracking().ToListAsync();
        }
    }
}
