using Microsoft.EntityFrameworkCore;
using Youtube.Application.Interfaces.Repositories;
using Youtube.Domain.Common;

namespace Youtube.Persistence.Repositories;
//public class WriteRepository<T,F> : IWriteRepository<T,F> where T : class, IEntityBase, new()

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{

    private readonly DbContext _dbContext;
   //private readonly EntityBase _entity;
    public WriteRepository(DbContext dbContext)
    {
            _dbContext = dbContext;

    }
    private DbSet<T> Table {get=>_dbContext.Set<T>();}
    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        

    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public  async Task HardDeleteAsync(T entity)
    {   //var entity = await Table.FindAsync(id);
         
        await Task.Run(()=> Table.Remove(entity));
    }

     public  async Task HardDeleteRangeAsync(IList<T> entities)
    {   //var entity = await Table.FindAsync(id);
         
        await Task.Run(()=> Table.RemoveRange(entities));
    }

    /*public async Task SoftDeleteAsync(F id)
    {
         //var entity = await Table.FindAsync(id);
         //_entity.IsDeleted = true;
         await Task. Run(()=> Table.Update(entity));
    }*/

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(()=> Table.Update(entity));
        return entity;
    }
}