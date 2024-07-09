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
    internal class InvoiceLineConfiguration : EntityTypeConfigurationBase<InvoiceLine,Guid>
    {
        public override void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder
                .ToTable("InvoiceLine", "sales");

            builder
                .HasOne(IL => IL.Product)
                .WithMany(P => P.InvoiceLines)
                .HasForeignKey(IL => IL.productId);

            builder
                .Property(IL => IL.productId)
                .IsRequired(true);

            builder
                .Property(IL => IL.Quantity)
                .IsRequired(true);

            builder
                .Property(IL => IL.TotalPrice)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
