using Youtube.Application.Bases;

namespace Youtube.Application.Features.Products.Excepitons;

public class ProductTitleMustNotBeSameException : BaseException
{
    public ProductTitleMustNotBeSameException(): base ("The title already exists"){}
}