using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    internal class CustomerModel : ModelEntityBase<Guid>
	{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Code { get; set; }
    public double Customerdepit { get; set; } = 0;
    public List<CustomerPaymentModel>? CustomerPayments { get; set; }
    public List<InvoiceModel>? Invoices { get; set; }

}
}
