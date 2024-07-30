using MediatR;
using Microsoft.EntityFrameworkCore;
using Youtube.Application.DTOs;
using Youtube.Application.Interfaces.AutoMapper;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Queries.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IList<GetAllProductQueryResponse>>
{
   
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
  
    public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
    }

    public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(x=> !x.IsDeleted,include: x => x.Include(p => p.Brand));
        //List<GetAllProductQueryResponse> returnList = new();
        //yproducts = await _context.Include(p =>p.Brand).ToLista();
        _mapper.Map<BrandDto,Brand>(new Brand());//burayı tam anlamadım
        /*foreach (var item in products)
        {
            returnList.Add(new GetAllProductQueryResponse(){
                Title = item.Title,
                Description = item.Description,

                Price = item.Price,
                Discount = item.Discount});
        }*/
        var response = _mapper.Map<GetAllProductQueryResponse,Product>(products).ToList();
        return response;

    }
}