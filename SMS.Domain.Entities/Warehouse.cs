using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
	public class Warehouse:EntityBase<Guid>
	{
		public string Name { get; set; }
		public string Location { get; set; }

		public List<Product> Products { get; set; }
	}
}
