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
    internal class PurchaseorderConfiguration : EntityTypeConfigurationBase<Purchaseorder, Guid>
    {
        public override void Configure(EntityTypeBuilder<Purchaseorder> builder)
        {
            builder
                .ToTable("Purchaseorder", "itemization");

            //public VendorModel? Vendor { get; set; }
            builder
                .HasOne(P => P.Vendor)
                .WithMany(V => V.Purchaseorder)
                .HasForeignKey(V => V.VendorId);

            builder
                .Property(p => p.Serial)
                .IsRequired(true);

            builder
                .Property(p => p.VendorId)
                .IsRequired(true);

            builder
                .Property(p => p.PODate)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
