using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class Purchaseorder:EntityBase<Guid>
	{
        public string Serial { get; set; }
		public Guid VendorId { get; set; }
		public DateTime PODate { get; set; }
		public Vendor Vendor { get; set; }
        public List<PurchasingExpenses>? PurchasingExpenses { get; set; }
    }
}
