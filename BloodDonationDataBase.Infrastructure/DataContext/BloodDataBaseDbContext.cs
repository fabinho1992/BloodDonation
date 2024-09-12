using BloodDonationDataBase.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Infrastructure.DataContext
{
    public class BloodDataBaseDbContext : DbContext
    {
        public BloodDataBaseDbContext(DbContextOptions<BloodDataBaseDbContext> options) : base(options)
        {
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
