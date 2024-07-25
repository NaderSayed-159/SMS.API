using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Patterns.Interfaces;

namespace SMS.Infrastructure.Query
{
    public static class Query
    {
        public static Task<TEntity> SelectByIdAsync<TEntity, TKey>(this IRepository<TEntity> repository, TKey id) where TEntity : EntityBase<TKey>
        {
            return repository
                .Queryable()
                .FirstOrDefaultAsync(q => q.Id.Equals(id));
        }

        public static Task<IEnumerable<TEntity>> SelectAsync<TEntity, TKey>(this IRepository<TEntity> repository) where TEntity : EntityBase<TKey>
        {
            return repository
                .Query()
                .SelectAsync();
        }
    }
}
