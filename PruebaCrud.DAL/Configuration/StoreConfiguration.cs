using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PruebaCrud.DAL.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .HasKey(e => e.StoreID);
            builder
                .Property(e => e.StoreID).IsRequired();

            builder
                .Property(e => e.Name).IsRequired();
            builder
                .Property(e => e.Name).HasMaxLength(50);

            builder
                .Property(e => e.Address ).IsRequired();
            builder
                .Property(e => e.Address).HasMaxLength(255);
        }
    }
}
