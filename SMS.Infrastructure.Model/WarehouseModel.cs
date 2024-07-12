using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    internal class WarehouseModel : ModelEntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public List<ProductModel>? Products { get; set; }
    }
}
