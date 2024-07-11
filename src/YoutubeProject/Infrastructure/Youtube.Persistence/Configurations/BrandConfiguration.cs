using Bogus;
using Microsoft.EntityFrameworkCore;
using Youtube.Domain.Entities;
namespace Youtube.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(e => e.Id);
        Faker faker= new Faker("tr");

        var brand1 = new Brand { Id = 1,Name = faker.Commerce.Department(),CreatedDate = DateTime.UtcNow,IsDeleted = false};
        var brand2 = new Brand { Id = 2,Name = faker.Commerce.Department(),CreatedDate = DateTime.UtcNow,IsDeleted = false};

        var brand3 = new Brand { Id = 3,Name = faker.Commerce.Department(),CreatedDate = DateTime.UtcNow,IsDeleted = false};
        var brand4 = new Brand { Id = 4,Name = faker.Commerce.Department(),CreatedDate = DateTime.UtcNow,IsDeleted = true};

        builder.HasData(brand1,brand2,brand3,brand4);

    }
}