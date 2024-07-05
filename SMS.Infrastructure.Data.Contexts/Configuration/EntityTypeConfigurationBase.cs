using System;
using SMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS.Infrastructure.Data.Contexts.Configuration
{
	public class EntityTypeConfigurationBase<TEntity, T> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase<T>
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder
				.HasKey(pk => pk.Id);


			if (typeof(T) == typeof(Guid))
			{
				builder
					.Property(p => p.Id)
					.ValueGeneratedOnAdd();
			}
		}
	}
}