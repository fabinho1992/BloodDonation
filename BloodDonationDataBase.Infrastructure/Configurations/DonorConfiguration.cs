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
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.ToTable("Donors");

            builder.HasKey(x => x.Id);  
            builder.Property(d => d.Name).HasMaxLength(50)
                .IsRequired();
            builder.Property(d => d.Email).HasMaxLength(80)
                .IsRequired();
            builder.HasIndex(d => d.Email).IsUnique();
            builder.Property(d => d.DateOfBirth).IsRequired();
            builder.Property(d => d.Age).IsRequired();
            builder.Property(d => d.Weight).HasMaxLength(3)
                .HasDefaultValue(0).IsRequired();
            builder.Property(d => d.Gender).HasConversion<string>()
                .IsRequired();
            builder.Property(d => d.BloodType).HasConversion<string>()
                .IsRequired();
            builder.Property(d => d.FactorRh).HasConversion<string>()
                .IsRequired();
            builder.HasMany(x => x.Donations)
                .WithOne(x => x.Donor)
                .HasForeignKey(x => x.DonorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Address)
               .WithOne(e => e.Donor)
               .HasForeignKey<Address>(e => e.DonorId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
