using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class Customer:EntityBase<Guid>
	{
        public string Name { get; set; }
        public string Code { get; set; }
        public double Customerdepit { get; set; }

        public List<CustomerPayment> CustomerPayments { get; set; }
        public List<Invoice> Invoices { get; set; }

	}
}
