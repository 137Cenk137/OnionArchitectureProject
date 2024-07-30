using MediatR;

namespace Youtube.Application.Features.Products.Command.Delete;

public class DeleteProductCommandRequest: IRequest<Unit>
{
    public int DeleteID { get; set; }
}