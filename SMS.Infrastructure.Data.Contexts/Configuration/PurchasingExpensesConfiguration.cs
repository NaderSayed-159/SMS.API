using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Data.Contexts.Configuration
{
    internal class PurchasingExpensesConfiguration : EntityTypeConfigurationBase<PurchasingExpenses, Guid>
    {
        public override void Configure(EntityTypeBuilder<PurchasingExpenses> builder)
        {
            builder
                .ToTable("PurchasingExpenses", "itemization");

            builder
                .HasOne(P => P.Vendor)
                .WithMany(V => V.PurchasingExpenses)
                .HasForeignKey(V => V.VendorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(P => P.Purchaseorder)
                .WithMany(V => V.PurchasingExpenses)
                .HasForeignKey(V => V.PurchaseOrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(p => p.PaiedAmount)
                .IsRequired(true);

            builder
                .Property(p => p.PurchaseOrderId)
                .IsRequired(true);

            builder
                .Property(p => p.VendorId)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
