using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    internal class PurchaseorderModel : ModelEntityBase<Guid>
    {
        [Required]
        public string Serial { get; set; }
        [Required]
        public Guid VendorId { get; set; }
        [Required]
        public DateTime PODate { get; set; }
        public VendorModel? Vendor { get; set; }
    }
}
