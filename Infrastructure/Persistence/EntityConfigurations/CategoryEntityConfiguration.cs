using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(b => b.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(i => i.Name).HasColumnType("name").HasColumnType("varchar").HasMaxLength(50);

            builder.Property(i => i.Description).HasColumnType("description").HasColumnType("varchar").HasMaxLength(250);

            builder.Property(i => i.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime").ValueGeneratedOnAdd()
               .HasDefaultValueSql("getdate()");

            builder.Property(i => i.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getdate()");

            builder.Property(i => i.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
        }
    }
}
