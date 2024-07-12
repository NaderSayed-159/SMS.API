	using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class PurchasingExpenses :EntityBase<Guid>
	{
		public double PaiedAmount { get; set; }
		public Guid VendorId { get; set; }
		public Guid PurchaseOrderId { get; set; }
		public Vendor Vendor { get; set; }
		public Purchaseorder? Purchaseorder { get; set; }
	}
}
