using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class CustomerPayment:EntityBase<Guid>
	{
		public double PaiedAmount { get; set; }
		public Guid CustomerId { get; set; }
		public Guid InvoiceId { get; set; }
		public Customer Customer { get; set; }
		public Invoice? Invoice { get; set; }
	}
}
