using MediatR;
using Youtube.Application.Interfaces.AutoMapper;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Products.Command.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
            _unitOfWork = unitOfWork;
    }


    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {

        var product  = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);


        /*product.Description  = request.Description == default ? product.Description : request.Description;

        product.Price  = request.Price == default ? product.Price : request.Price;
        product.BrandId  = request.BrandId == default ? product.BrandId : request.BrandId;
        product.Discount  = request.Discount == default ? product.Discount : request.Discount;
        product.Title  = request.Title == default ? product.Title : request.Title;
        product.Categories  = request.CategoryIds == default ? product.Categories : EasyCollection(request.CategoryIds.ToList(),product.Id);*/
        
        //var map = _mapper.Map<Product,UpdateProductCommandRequest>(request);
        Product map = new(){
            Title = request.Title,
            Description = request.Description,
            BrandId = request.BrandId,
            Discount = request.Discount

        };

       

        var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x => x.ProductId == product.Id);

        await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

        foreach (var categoryId in request.CategoryIds)
        {
            await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new(){CategoryId = categoryId,ProductId = product.Id});
        }
        map.Categories=  await _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x => x.ProductId == product.Id);


        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }

    private ICollection<ProductCategory> EasyCollection(List<int> ints, int productId)
    {
        List<ProductCategory> categories = new List<ProductCategory>();
        ints.ForEach(data => {
            categories.Add(new ProductCategory(){CategoryId = data,ProductId = productId });
        });
        return categories;
    }
}