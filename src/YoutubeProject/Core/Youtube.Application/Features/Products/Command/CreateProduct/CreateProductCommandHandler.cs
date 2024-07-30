using MediatR;
using Youtube.Application.Features.Products.Rules;
using Youtube.Application.Interfaces.AutoMapper;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ProductRules _rules;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ProductRules rules)
    {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rules = rules;
    }

    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

        await _rules.ProductTitleMustNotBeSame(products,request.Title);
        //var product = _mapper.Map<Product,CreateProductCommandRequest>(request);

        Product product = new(request.Title,request.Description,request.Price,request.Discount,request.BrandId);


        await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
        


        if(await _unitOfWork.SaveChangesAsync()> 0)
        {
            foreach (var categoryId in request.CategoryIds)
            {   
               
                await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(
                     new ProductCategory(){CategoryId = categoryId, ProductId = product.Id}
                );
            }
            await _unitOfWork.SaveChangesAsync();
        }
        return Unit.Value;
    }
}