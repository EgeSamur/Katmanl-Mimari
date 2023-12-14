
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Project.Common.Paging;
using Project.DataAccess.Abstract.Base;
using Project.Entities.Base;
using Project.Entities.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Project.DataAccess.Concrete.Base;

public class RepositoryBase<TEntity,TContext> : IRepository<TEntity> where TEntity : BaseEntity,new() where TContext:DbContext
{
    protected readonly TContext Context;

    public RepositoryBase(TContext context)
    {
        Context = context;
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    #region GET
    // enableTracking eğer tek bir user çekiyor isem genelde bu durumda user update edileceği için enableTrue değernini true yaparız.
    // yani enableTracking yapıldığında db.SaveChange metgodunu kullanmamıza gerek kalmaz.
    public TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool enableTracking = true
    )
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        return queryable.FirstOrDefault(predicate);
    }



    public async Task<TEntity?> GetAsync(
    Expression<Func<TEntity, bool>> predicate,
    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
    bool enableTracking = true,
    CancellationToken cancellationToken = default
)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }
    #endregion

    #region GET_LIST
    public IPaginate<TEntity> GetList(
       Expression<Func<TEntity, bool>>? predicate = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
       int index = 0,
       int size = 10,
       bool enableTracking = false
   )
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return orderBy(queryable).ToPaginate(index, size);
        return queryable.ToPaginate(index, size);
    }

    public async Task<IPaginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, from: 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, from: 0, cancellationToken);
    }
    #endregion

    #region CREATE
    public void Add(TEntity entity)
    {
        Context.Add(entity);
        Context.SaveChanges();
    }

    public void AddRange(IList<TEntity> entities)
    {
        Context.AddRange(entities);
        Context.SaveChanges();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IList<TEntity> entities)
    {
        await Context.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }
    #endregion

    #region UPDATE
    public void Update(TEntity entity)
    {
        Context.Update(entity);
        Context.SaveChanges();
    }

    public void UpdateRange(IList<TEntity> entities)
    {
        Context.UpdateRange(entities);
        Context.SaveChanges();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await Task.Run(() => Context.Update(entity));
        await Context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IList<TEntity> entities)
    {
        await Task.Run(() => Context.UpdateRange(entities));
        await Context.SaveChangesAsync();
    }
    #endregion

    #region DELETE
    public void Delete(TEntity entity)
    {
        Context.Remove(entity); 
        Context.SaveChanges();
    }

    public void DeleteRange(IList<TEntity> entities)
    {
        Context.RemoveRange(entities);
        Context.SaveChanges();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await Task.Run(() => Context.Remove(entity));
        await Context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IList<TEntity> entities)
    {
        await Task.Run(() => Context.RemoveRange(entities));
        await Context.SaveChangesAsync();
    }
    #endregion

    #region ANY
    public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = false)
    {
        IQueryable<TEntity> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        return queryable.Any();
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool enableTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        return await queryable.AnyAsync(cancellationToken);
    }

  
    #endregion
}
