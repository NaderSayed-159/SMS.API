using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Infrastructure.Data.Contexts.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Data.Contexts
{
    public class SMSDBContext:DbContext
    {
        public SMSDBContext():base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NERO\\SQLEXPRESS;Initial Catalog=SMS;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayment { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchaseorder> Purchaseorder { get; set; }
        public virtual DbSet<PurchasingExpenses> PurchasingExpenses { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerPaymentConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceLineConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseorderConfiguration());
            modelBuilder.ApplyConfiguration(new PurchasingExpensesConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
