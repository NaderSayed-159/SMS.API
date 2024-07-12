using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    internal class ProductModel : ModelEntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required]
        public string InternalCode { get; set; }
        public Guid WarehouseId { get; set; }
        [Required]
        public double StockAmount { get; set; }
        public WarehouseModel Warehouse { get; set; }
        public List<InvoiceLineModel>? InvoiceLines { get; set; }

    }
}
