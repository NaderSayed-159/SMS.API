using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Domain.Patterns.Interfaces
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

		Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters,
			CancellationToken cancellationToken = default);
	}
}