using SGPC.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGPC.ViewModels
{
	public class TicketViewModel
	{


		[Display(Name = "Name", ResourceType = typeof(TicketResource))]
		public string Name { get; set; }
		[Display(Name = "Subject", ResourceType = typeof(TicketResource))]
		public string Subject { get; set; }

		[Display(Name = "Description", ResourceType = typeof(TicketResource))]
		public string Description { get; set; }

		[Display(Name = "Address", ResourceType = typeof(TicketResource))]
		public string Address { get; set; }

		[Display(Name = "Address", ResourceType = typeof(TicketResource))]
		public string ReferBy { get; set; }

		public string Contact { get; set; }


		public string PhoneNo { get; set; }

		[Display(Name = "MobileNo", ResourceType = typeof(TicketResource))]
		public string MobileNo { get; set; }


		[Display(Name = "Status", ResourceType = typeof(TicketResource))]
		public int Status { get; set; }

		public Guid Id { get; set; }
	}
}
