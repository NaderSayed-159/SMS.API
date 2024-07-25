using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    public class PurchasingExpensesModel : ModelEntityBase<Guid>
    {
        [Required]
        public double PaiedAmount { get; set; }
        [Required]
        public Guid VendorId { get; set; }
        [Required]
        public Guid PurchaseOrderId { get; set; }
        public VendorModel? Vendor { get; set; }
        public PurchaseorderModel? Purchaseorder { get; set; }
    }
}
