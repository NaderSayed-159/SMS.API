using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class InvoiceLine:EntityBase<Guid>
	{
        public Guid productId { get; set; }
        public int Quantity { get; set; }
		public double TotalPrice { get; set; }
		public Product Product { get; set; }
    }
}
