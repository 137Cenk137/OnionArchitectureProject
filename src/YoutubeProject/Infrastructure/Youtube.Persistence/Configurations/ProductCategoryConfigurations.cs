using Microsoft.EntityFrameworkCore;
using Youtube.Domain.Entities;

namespace Youtube.Persistence.Configurations;

public class ProductCategoryConfigurations : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x => new{x.ProductId,x.CategoryId});





        builder.HasOne(x => x.Product).WithMany(x => x.Categories).HasForeignKey(x=> x.ProductId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}