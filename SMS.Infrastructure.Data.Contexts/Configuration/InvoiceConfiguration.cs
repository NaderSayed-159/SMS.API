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
    internal class InvoiceConfiguration : EntityTypeConfigurationBase<Invoice,Guid>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
                .ToTable("Invoice", "sales");

            builder
                .HasOne(I => I.Customer)
                .WithMany(C => C.Invoices)
                .HasForeignKey(I => I.CustomerId);

            builder.Property(I => I.InvoiceDate)
                .IsRequired(true);

            builder.Property(I => I.Serial)
                .IsRequired(true);

            builder.Property(I => I.CustomerId)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
