using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Youtube.Domain.Common;

namespace Youtube.Application.Interfaces.Repositories;


public interface IReadRepository<T>  where  T : class , IEntityBase,new() 
{
    Task<IList<T>> GetAllAsync(Expression<Func<T,bool>>? predicate = null,
                                Func<IQueryable<T>,IIncludableQueryable<T,object>>? include = null,
                                Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
                                bool enableTracking = false);
     Task<IList<T>> GetAllByPagingAsync(Expression<Func<T,bool>>? predicate = null,
                                Func<IQueryable<T>,IIncludableQueryable<T,object>>? include = null,
                                Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
                                bool enableTracking = false,int currentPage = 1, int pageSize = 3);
     Task<IList<T>> GetAsync(Expression<Func<T,bool>> predicate,
                                Func<IQueryable<T>,IIncludableQueryable<T,object>>? include = null,
                                bool enableTracking = false);
     Task<T> Find(Expression<Func<T,bool>> predicate);
     Task<T> CoutnAsync(Expression<Func<T,bool>>? predicate = null);

}

    




