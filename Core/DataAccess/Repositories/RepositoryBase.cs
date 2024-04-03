using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Drawing;
using System.Linq.Expressions;
using System.Threading;

namespace Core.DataAccess.Repositories;

public class RepositoryBase<TEntity, TId, TContext>
	: IRepository<TEntity, TId>, IAsyncRepository<TEntity, TId>
	where TEntity : Entity<TId>
	where TContext : DbContext
{
	protected DbSet<TEntity> _entity;
	protected readonly TContext _context;
    public RepositoryBase(TContext context)
    {
	   _context = context;
       _entity = _context.Set<TEntity>();
    }

    public TEntity Add(TEntity entity)
	{
		var addedEntity = _entity.Add(entity);
		_context.SaveChanges();
		return entity;
	}

	public async Task<TEntity> AddAsync(TEntity entity)
	{
		var addedEntity =  await _entity.AddAsync(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public IList<TEntity> AddRange(IList<TEntity> entities)
	{
		foreach (TEntity entity in entities)
			entity.CreatedDate = DateTime.UtcNow;
		 _context.AddRangeAsync(entities);
		 _context.SaveChangesAsync();
		return entities;
	}

	public Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
	{
		throw new NotImplementedException();
	}

	public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = true)
	{
		throw new NotImplementedException();
	}

	public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public TEntity Delete(TEntity entity)
	{
		throw new NotImplementedException();
	}

	public Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
	{
		throw new NotImplementedException();
	}

	public IList<TEntity> DeleteRange(IList<TEntity> entity)
	{
		throw new NotImplementedException();
	}

	public Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false)
	{
		throw new NotImplementedException();
	}

	public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true)
	{
		throw new NotImplementedException();
	}

	public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<TEntity> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true)
	{
		IQueryable<TEntity> queryable = Query();
		if (!enableTracking)
			queryable = queryable.AsNoTracking();
		if (include != null)
			queryable = include(queryable);
		if (withDeleted)
			queryable = queryable.IgnoreQueryFilters();
		if (predicate != null)
			queryable = queryable.Where(predicate);
		if (orderBy != null)
			return orderBy(queryable);
		return queryable;
	}

	public Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public IQueryable<TEntity> Query() => _entity;


	public TEntity Update(TEntity entity)
	{
		throw new NotImplementedException();
	}

	public Task<TEntity> UpdateAsync(TEntity entity)
	{
		throw new NotImplementedException();
	}

	public IList<TEntity> UpdateRange(IList<TEntity> entities)
	{
		throw new NotImplementedException();
	}

	public Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
	{
		throw new NotImplementedException();
	}

}
