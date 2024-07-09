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
    internal class WarehouseConfiguration : EntityTypeConfigurationBase<Warehouse, Guid>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder) 
        {
            builder
                .ToTable("Warehouse", "itemization");

            builder.Property(P => P.Name)
                .IsRequired(true);

            builder.Property(P => P.Location)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
