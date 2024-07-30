using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementDomainLayer.Entities.Concretes;

namespace ProductManagementDataAccess.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnType("nvarchar(30)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("nvarchar(60)").IsRequired();
            builder.Property(p => p.Discount).HasColumnType("float").IsRequired();
            builder.Property(p => p.Price).HasColumnType("float").IsRequired();
            builder.Property(p => p.ImageLink).HasColumnName("Image Link").HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
