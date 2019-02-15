using AccountCore.DataModels;
using Database.EF.Models;
using SGPC.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGPC.EF.dbmodel.Models
{
	public class TicketUserLink : BaseModel
	{
		public Guid UserId { get; set; }
		[ForeignKey("UserId")]
		public ApplicationUsers applicationUsers { get; set; }
		


		public Guid TktId { get; set; }
		[ForeignKey("TktId")]
		public virtual Ticket TicketFK { get; set; }
		

		public int TicketStatus { get; set; }

	}
}
