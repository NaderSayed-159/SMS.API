using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class Invoice:EntityBase<Guid>
	{
        public string Serial { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Customer Customer { get; set; }
        
        public List<CustomerPayment>? CustomerPayment { get; set; }
    }
}
