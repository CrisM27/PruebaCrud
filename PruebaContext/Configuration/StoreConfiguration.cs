using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PruebaContext.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .Property(e => new { e.ID, e.Name, e.Address }).IsRequired();

            builder
                .HasKey(e => e.ID);

            builder
                .Property(e => e.Name).HasMaxLength(50);

            builder
                .Property(e => e.Address).HasMaxLength(255);
        }
    }
}
