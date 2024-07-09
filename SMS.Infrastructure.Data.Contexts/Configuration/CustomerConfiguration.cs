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
    internal class CustomerConfiguration : EntityTypeConfigurationBase<Customer,Guid>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("Customer", "sales");

            builder.Property(P => P.Name)
                .IsRequired(true);

            builder.Property(P => P.Code)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
