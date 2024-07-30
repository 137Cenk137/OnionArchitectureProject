using Youtube.Application.Interfaces.Repositories;
using Youtube.Domain.Common;

namespace Youtube.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class,IEntityBase,new();
    IWriteRepository<T> GetWriteRepository<T>() where T: class,IEntityBase,new();
    Task<int> SaveChangesAsync();
    int Save();
}