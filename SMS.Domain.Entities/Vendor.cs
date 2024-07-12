using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class Vendor:EntityBase<Guid>
	{
		public string Name { get; set; }
		public string Code { get; set; }

		public List<Purchaseorder>? Purchaseorder { get; set; }
        public List<PurchasingExpenses>? PurchasingExpenses { get; set; }

    }
}
