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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.Street).HasMaxLength(150)
                .IsRequired();
            builder.Property(a => a.City).HasMaxLength(30)
                .IsRequired();
            builder.Property(a => a.State).HasColumnType("NVARCHAR")
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(a => a.ZipCode).HasColumnType("NVARCHAR")
                .HasMaxLength(9)
                .IsRequired();
            builder.Property(a => a.Complement).HasMaxLength(50)
                .IsRequired();
            builder.Property(a => a.DonorId).IsRequired();
        }
    }
}
