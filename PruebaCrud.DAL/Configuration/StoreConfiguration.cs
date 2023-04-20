using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaCrud.Domain.Entities;

namespace PruebaCrud.DAL.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .ToTable("Store")
                .HasKey(e => e.StoreID);
            builder
                .Property(e => e.StoreID)
                .HasColumnName("Store_ID")
                .IsRequired();

            builder
                .Property(e => e.Name)
                .HasColumnName("Store_Name")
                .IsRequired();
            builder
                .Property(e => e.Name).HasMaxLength(50);

            builder
                .Property(e => e.Address )
                .HasColumnName("Store_Address")
                .IsRequired();
            builder
                .Property(e => e.Address).HasMaxLength(255);
        }
    }
}
