using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    internal class InvoiceLineModel : ModelEntityBase<Guid>
    {
        [Required]
        public Guid productId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public ProductModel? Product { get; set; }
    }
}
