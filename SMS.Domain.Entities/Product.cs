using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class Product:EntityBase<Guid>
	{
        public string Name { get; set; }
        public double Price { get; set; }
		public string InternalCode { get; set; }
		public Guid WarehouseId { get; set; }
		public double StockAmount { get; set; }
		public Warehouse Warehouse { get; set; }
		public List<InvoiceLine>? InvoiceLines { get; set; }

	}
}
