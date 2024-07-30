using Youtube.Application.DTOs;

namespace Youtube.Application.Features.Queries.GetAllProduct;

public class GetAllProductQueryResponse
{
    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
    public decimal Discount { get; set; }

    public BrandDto Brand { get; set; } //isin onemli Brand isim konmali cünkü mapplaerken yapıtoruz
    
}