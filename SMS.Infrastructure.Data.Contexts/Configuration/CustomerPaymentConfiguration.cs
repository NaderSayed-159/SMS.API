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
    internal class CustomerPaymentConfiguration:EntityTypeConfigurationBase<CustomerPayment,Guid>
    {
        public override void Configure(EntityTypeBuilder<CustomerPayment> builder)
        {

            builder
                .ToTable("CustomerPayment", "sales");

            builder
                .HasOne(CP => CP.Customer)
                .WithMany(C => C.CustomerPayments)
                .HasForeignKey(CP => CP.CustomerId);

            builder
                .HasOne(CP => CP.Invoice)
                .WithMany(I => I.CustomerPayment)
                .HasForeignKey(CP => CP.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(CP => CP.PaiedAmount)
                .IsRequired(true);

            builder.Property(CP => CP.CustomerId)
                .IsRequired(true);

            builder.Property(CP => CP.InvoiceId)
                .IsRequired(true);

            base.Configure(builder);
        }
    }
}
