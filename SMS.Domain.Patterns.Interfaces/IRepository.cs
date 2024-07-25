using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Patterns.Interfaces
{
	public interface IRepository<TEntity>
	{
		Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default);
		Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);
		Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes = null);
		Task<IEnumerable<TEntity>> FindAllAsync(string[] includes = null);
		Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default);
		Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);

		Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property,
			CancellationToken cancellationToken = default);

		void Attach(TEntity item);
		void Detach(TEntity item);
		void Insert(TEntity item);
		void Update(TEntity item);
		void Delete(TEntity item);
		Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default);
		Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);
		IQueryable<TEntity> Queryable();
		IQueryable<TEntity> QueryableSql(string sql, params object[] parameters);
		Task<bool> CanConnectAsync();
	}
}
