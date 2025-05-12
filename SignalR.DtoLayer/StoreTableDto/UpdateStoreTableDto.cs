using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.StoreTableDto
{
	public class UpdateStoreTableDto
	{
		public int StoreTableID { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }
	}
}
