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
      public required int ParentId { get; set; }
      public required string Name { get; set; }
      public required int  Priorty { get; set; }
      public ICollection<Detail> Details  { get; set; }

}