using BloodDonationDataBase.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Infrastructure.Configurations
{
    public class BloodStockConfiguration : IEntityTypeConfiguration<BloodStock>
    {
        public void Configure(EntityTypeBuilder<BloodStock> builder)
        {
            builder.ToTable("BloodStocks");

            builder.HasKey(x => x.Id);
            builder.Property(b => b.BloodType).HasConversion<string>()
                .IsRequired();
            builder.Property(b => b.FactorRh).HasConversion<string>()
                .IsRequired();
            builder.Property(b => b.QuantityMl).IsRequired();
        }
    }
}
