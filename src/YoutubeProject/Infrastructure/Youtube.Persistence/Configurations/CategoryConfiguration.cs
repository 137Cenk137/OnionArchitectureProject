

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Youtube.Domain.Entities;

namespace Youtube.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        Category parent1  = new(){
            Id = 1,
            Name = "Elektrik",
            Priorty = 1,
            ParentId = 0,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow
        } ;
        Category parent2  = new(){
            Id = 2,
            Name = "Moda",
            Priorty = 1,
            ParentId = 0,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow
        } ;
        Category child1  = new(){
            Id = 3,
            Name = "bilgisayar",
            Priorty = 1,
            ParentId = 1,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow 
        } ;
        Category child2  = new(){
            Id = 4,
            Name = "Kadın",
            Priorty = 1,
            ParentId = 2,
            IsDeleted = false,
            CreatedDate = DateTime.UtcNow
        } ;
        builder.HasData(parent1,parent2,child1, child2);
    }
}