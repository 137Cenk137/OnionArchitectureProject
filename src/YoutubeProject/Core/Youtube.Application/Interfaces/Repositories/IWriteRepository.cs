using Youtube.Domain.Common;

namespace Youtube.Application.Interfaces.Repositories;



//
public interface IWriteRepository<T> where T : class,IEntityBase,new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);

    Task<T> UpdateAsync(T entity);

    Task HardDeleteAsync(T entity);
     Task HardDeleteRangeAsync(IList<T> entities);
    /*Task SoftDeleteAsync(F id);*/

}