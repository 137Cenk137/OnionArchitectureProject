using Youtube.Domain.Common;

namespace Youtube.Domain.Entities;

public class Category : EntityBase ,IEntityBase
{
    public Category()
    {
        
    }
    public Category(int parentid , string name, int priorty)
    {
        ParentId = parentid;
        Name = name;
        Priorty = priorty;
    }
      public  int ParentId { get; set; }
      public  string Name { get; set; }
      public  int  Priorty { get; set; }
      public ICollection<Detail> Details  { get; set; }
      public ICollection<ProductCategory> Products { get; set; }

}