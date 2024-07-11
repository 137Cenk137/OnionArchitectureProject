using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Youtube.Domain.Entities;

namespace Youtube.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        builder.HasKey(x => x.Id);

        Faker faker= new Faker("tr");
        Detail detail = new(){
            Id = 1,
            Title = faker.Lorem.Sentence(1,2),
            Description = faker.Lorem.Sentence(5),
            CreatedDate = DateTime.UtcNow,
            CategoryId  = 1,
            IsDeleted = false
            
        };
        Detail detail2  = new(){
            Id = 2,
            Title = faker.Lorem.Sentence(1,2),
            Description = faker.Lorem.Sentence(5),
            CreatedDate = DateTime.UtcNow,
            CategoryId  = 3,
            IsDeleted = true
            
        };
        Detail detai3 = new(){
            Id = 3,
            Title = faker.Lorem.Sentence(1,2),
            Description = faker.Lorem.Sentence(5),
            CreatedDate = DateTime.UtcNow,
            CategoryId  = 4,
            IsDeleted = false
            
        };
        builder.HasData(detail,detail2, detai3);
    }
}