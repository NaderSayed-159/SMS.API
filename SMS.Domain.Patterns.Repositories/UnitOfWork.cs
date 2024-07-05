using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SMS.Domain.Patterns.Interfaces;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Patterns.Interfaces;

namespace eSealClientSample.Domain.Patterns.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(DbContext context)
		{
			Context = context;
		}

		protected DbContext Context { get; }

		public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await Context.SaveChangesAsync(cancellationToken);
		}

		public virtual async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters,
			CancellationToken cancellationToken = default)
		{
			return await Context.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
		}
	}
}