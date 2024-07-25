using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SMS.Domain.Patterns.Interfaces;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Patterns.Interfaces;
using SMS.Infrastructure.Data.Contexts;

namespace eSealClientSample.Domain.Patterns.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(SMSDBContext context)
		{
			Context = context;
		}

		protected SMSDBContext Context { get; }

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