using Microsoft.EntityFrameworkCore.Query;
using Project.Common.Paging;
using Project.Entities.Base;
using Project.Entities.Entities;
using System.Linq.Expressions;

namespace Project.DataAccess.Abstract.Base;

public interface IRepository<T> : IQuery<T> where T : BaseEntity, new()
{
    #region GET
    T? Get(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = true
    );


    Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = true, // bir tane çekiyorsak update yapabilme ihtimali var diye .
        CancellationToken cancellationToken = default
    );
    #endregion

    #region GET_LIST
    IPaginate<T> GetList(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = false
    );

    Task<IPaginate<T>> GetListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = false,
        CancellationToken cancellationToken = default
    );
    #endregion


    #region CREATE
    void Add(T entity);
    void AddRange(IList<T> entities);

    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entity);
    #endregion

    #region UPDATE
    void Update(T entity);
    void UpdateRange(IList<T> entities);

    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IList<T> entity);
    #endregion

    #region DELETE
    void Delete(T entity);
    void DeleteRange(IList<T> entity);

    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IList<T> entity);
    #endregion


    #region ANY
    bool Any(Expression<Func<T, bool>>? predicate = null, bool enableTracking = false);

    Task<bool> AnyAsync(
        Expression<Func<T, bool>>? predicate = null,
        bool enableTracking = false,
        CancellationToken cancellationToken = default
    );
    #endregion
}

