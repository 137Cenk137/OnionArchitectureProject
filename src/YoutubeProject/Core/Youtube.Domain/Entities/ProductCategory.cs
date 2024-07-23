using Youtube.Domain.Common;

namespace Youtube.Domain.Entities;

public class ProductCategory : IEntityBase
{
    public int CategoryId { get; set; }
    public int ProductId { get; set; }

    public Category Category { get; set; }
    public Product Product { get; set; }
}