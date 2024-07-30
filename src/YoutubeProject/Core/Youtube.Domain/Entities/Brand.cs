using Youtube.Domain.Common;

namespace Youtube.Domain.Entities;


public class Brand : EntityBase , IEntityBase
{
    public Brand()
    {
        
    }   
    public Brand(string name){
        Name = name;
    }
    public  string Name { get; set; }
}