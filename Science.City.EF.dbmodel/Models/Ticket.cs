using Database.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGPC.EF.Models
{
	public class Ticket : BaseModel
	{

		public string Name { get; set; }

		public string Subject { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public string ReferBy { get; set; }

		public string Contact { get; set; }

		public string PhoneNo { get; set; }

		public string MobileNo { get; set; }

		public int Status { get; set; }

	}
}
