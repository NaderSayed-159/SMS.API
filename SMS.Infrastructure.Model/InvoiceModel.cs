using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    internal class InvoiceModel : ModelEntityBase<Guid>
    {
        [Required]
        public string Serial { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        public CustomerModel Customer { get; set; }

        public List<CustomerPaymentModel>? CustomerPayment { get; set; }
    }
}
