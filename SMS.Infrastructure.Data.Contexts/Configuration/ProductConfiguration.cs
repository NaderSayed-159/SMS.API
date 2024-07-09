using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Data.Contexts.Configuration
{
	public class ProductConfiguration : EntityTypeConfigurationBase<Product, Guid>
	{
		public override void Configure(EntityTypeBuilder<Product> builder)
		{
			builder
				.ToTable("Products", "itemization");

            builder
                .HasOne(p => p.Warehouse)
                .WithMany(W => W.Products)
                .HasForeignKey(p => p.WarehouseId);

            builder
				.Property(p => p.Name)
				.IsRequired(true);

            builder
                .Property(p => p.InternalCode)
                .IsRequired(true);

            builder
                .Property(p => p.StockAmount)
                .IsRequired(true);

            base.Configure(builder);
		}
	}
}
