using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Model
{
    public class WarehouseModel : ModelEntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public List<ProductModel>? Products { get; set; }
    }
}
