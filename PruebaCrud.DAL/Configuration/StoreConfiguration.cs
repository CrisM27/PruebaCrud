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
                .Property(e => e.Country)
                .HasColumnName("Country")
                .IsRequired();
            builder
                .Property(e => e.Country).HasMaxLength(50);

            builder
                .Property(e => e.State)
                .HasColumnName("State")
                .IsRequired();
            builder
                .Property(e => e.State).HasMaxLength(50);

            builder
                .Property(e => e.City)
                .HasColumnName("City")
                .IsRequired();
            builder
                .Property(e => e.City).HasMaxLength(50);

            builder
                .Property(e => e.Zipcode)
                .HasColumnName("Zip_Code")
                .IsRequired();
            builder
                .Property(e => e.City).HasMaxLength(5);

            builder
                .Property(e => e.Address )
                .HasColumnName("Store_Address")
                .IsRequired();
            builder
                .Property(e => e.Address).HasMaxLength(255);
        }
    }
}
