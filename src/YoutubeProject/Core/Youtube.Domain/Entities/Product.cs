using Youtube.Domain.Common;

namespace Youtube.Domain.Entities;

public class Product : EntityBase
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int BrandId { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    

    public Brand Brand { get; set; }
    //public string ImagePath { get; set; }
}