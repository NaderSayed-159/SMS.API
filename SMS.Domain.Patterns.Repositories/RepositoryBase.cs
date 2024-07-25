using Microsoft.EntityFrameworkCore;
using SMS.Domain.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Patterns.Repositories
{
	public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected DbContext Context { get; }
		protected DbSet<TEntity> Set { get; }
		protected RepositoryBase(DbContext context)
		{

			Context = context;
			Set = context.Set<TEntity>();
		}


		public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
		{
			return await Set.FindAsync(keyValues, cancellationToken);
		}

		public virtual async Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
		{
			return await FindAsync(new object[] { keyValue }, cancellationToken);
		}

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes = null)
        {
			IQueryable<TEntity> query = Set;
            if (includes != null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			return await query.Where(criteria).ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(string[] includes = null)
        {
            IQueryable<TEntity> query = Set;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }
        public virtual async Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default)
		{
			var item = await FindAsync(keyValues, cancellationToken);
			return item != null;
		}

		public virtual async Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
		{
			return await ExistsAsync(new object[] { keyValue }, cancellationToken);
		}

		public virtual async Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property,
			CancellationToken cancellationToken = default)
		{
			await Context.Entry(item).Reference(property).LoadAsync(cancellationToken);
		}

		public virtual void Attach(TEntity item)
		{
			Set.Attach(item);
		}

		public virtual void Detach(TEntity item)
		{
			Context.Entry(item).State = EntityState.Detached;
		}

		public virtual void Insert(TEntity item)
		{
			Context.Entry(item).State = EntityState.Added;
		}

		public virtual void Update(TEntity item)
		{
			Context.Entry(item).State = EntityState.Modified;
		}

		public virtual void Delete(TEntity item)
		{
			Context.Entry(item).State = EntityState.Deleted;
		}

		public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
		{
			var item = await FindAsync(keyValues, cancellationToken);
			if (item == null) return false;
			Context.Entry(item).State = EntityState.Deleted;
			return true;
		}

		public virtual async Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
		{
			return await DeleteAsync(new object[] { keyValue }, cancellationToken);
		}

		public virtual IQueryable<TEntity> Queryable()
		{
			return Set;
		}

		public virtual IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
		{
			return Set.FromSqlRaw(sql, parameters);
		}

		public async Task<bool> CanConnectAsync()
		{
			return await Context.Database.CanConnectAsync();
		}


    }
}
