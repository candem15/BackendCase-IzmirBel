using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(b => b.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(i => i.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(50);

            builder.Property(i => i.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(250);

            builder.Property(i => i.Quantity).HasColumnName("Quantity").HasColumnType("float").IsRequired();

            builder.Property(i => i.Price).HasColumnName("Price").HasColumnType("money").IsRequired();

            builder.Property(i => i.Unit).HasColumnName("Unit").HasColumnType("varchar").HasMaxLength(10).IsRequired();

            builder.Property(i => i.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Property(i => i.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getdate()");

            builder.Property(i => i.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false).IsRequired();

            builder.HasOne(i => i.Category)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
