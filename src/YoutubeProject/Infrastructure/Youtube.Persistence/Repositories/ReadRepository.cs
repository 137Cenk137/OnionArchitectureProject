using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Youtube.Application.Interfaces.Repositories;
using Youtube.Domain.Common;

namespace Youtube.Persistence.Repositories;
//bizim projemizde tüm katmamlarda kullanacagimiz bu classlar tek bir yerden yonelitiliyor olacak 
public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
{
    private readonly DbContext _dbContext ;
    public ReadRepository(DbContext dbContext)
    {
            _dbContext = dbContext;
    }

    private DbSet<T> Table {get => _dbContext.Set<T>();}
    public async Task<int> CoutnAsync(Expression<Func<T, bool>>? predicate = null)
    {
        Table.AsNoTracking();
        return await Table.Where(predicate).CountAsync();
    }

    public async Task<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking = false)
    {
        if(!enableTracking){Table.AsNoTracking();}
        return await Table.FindAsync(predicate);
    }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;
        if(!enableTracking){queryable.AsNoTracking();}
        if(include is not null){queryable = include(queryable);}
        if (predicate is not null){queryable = queryable.Where(predicate);}
        if (orderBy is not null){return await orderBy(queryable).ToListAsync();}

        return await queryable.ToListAsync();
    }

    public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
    {

        IQueryable<T> queryable = Table;
        if(!enableTracking){queryable.AsNoTracking();}
        if(include is not null){queryable = include(queryable);}
        if (predicate is not null){queryable = queryable.Where(predicate);}
        if (orderBy is not null){return await orderBy(queryable).Skip((currentPage-1) * pageSize).Take(pageSize).ToListAsync();}

        return await queryable.Skip((currentPage-1) * pageSize).Take(pageSize).ToListAsync();    }

    public  async Task<T> GetAsync(Expression<Func<T, bool>> predicate , Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
         IQueryable<T> queryable = Table;
        if(!enableTracking){queryable.AsNoTracking();}
        if(include is not null){queryable = include(queryable);}
        //queryable.Where(predicate);


        return await queryable.FirstOrDefaultAsync();   
    }
}