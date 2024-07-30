using Microsoft.EntityFrameworkCore;
using Youtube.Application.Interfaces.Repositories;
using Youtube.Application.Interfaces.UnitOfWorks;
using Youtube.Persistence.Context;
using Youtube.Persistence.Repositories;

namespace Youtube.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        _appDbContext = dbContext;
    }
    public async ValueTask DisposeAsync() => await  _appDbContext.DisposeAsync();
   


    public int Save() => _appDbContext.SaveChanges();
   

    public async Task<int> SaveChangesAsync() => await _appDbContext.SaveChangesAsync();
    

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_appDbContext) ;
  

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_appDbContext);
    
}