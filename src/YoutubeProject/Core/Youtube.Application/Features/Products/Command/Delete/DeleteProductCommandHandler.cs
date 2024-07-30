
using MediatR;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Products.Command.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest,Unit>
{

    private readonly IUnitOfWork _unitOfWork;
    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
            _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(predicate: x => x.Id == request.DeleteID && !x.IsDeleted);
        if (product == null)
        {
            throw new Exception("not found");
        }
        product.IsDeleted = true;
        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;




        /*var product1 = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.DeleteID && !x.IsDeleted,enableTracking:true);
        product1.IsDeleted = true;
       
        await _unitOfWork.SaveChangesAsync();*/

 



        
    }
}