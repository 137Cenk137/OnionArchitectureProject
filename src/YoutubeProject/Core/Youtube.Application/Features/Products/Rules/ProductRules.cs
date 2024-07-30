using Youtube.Application.Bases;
using Youtube.Application.Features.Products.Excepitons;
using Youtube.Domain.Entities;

namespace Youtube.Application.Features.Products.Rules;

public class ProductRules : BaseRules
{
    public Task ProductTitleMustNotBeSame(IList<Product> products ,string requestTitle )
    {
        /*foreach (var item in products )
        {
            if (item.Title == requestTitle)
               { throw new ProductTitleMustNotBeSameException();}
        }*/

        if(products.Any(x => x.Title == requestTitle))
        {throw new ProductTitleMustNotBeSameException();}
        
            
    

        return Task.CompletedTask;
    }
}