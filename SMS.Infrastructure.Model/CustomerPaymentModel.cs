using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    internal class CustomerPaymentModel : ModelEntityBase<Guid>
    {
        [Required]
        public double PaiedAmount { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid InvoiceId { get; set; }
        public CustomerModel Customer { get; set; }
        public InvoiceModel? Invoice { get; set; }
    }
}
