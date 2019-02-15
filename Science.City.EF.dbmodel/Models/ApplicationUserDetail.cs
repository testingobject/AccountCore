using AccountCore.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.EF.Models
{
	public class ApplicationUserDetail : BaseModel
	{

		[ForeignKey("applicationUsers")]
		public Guid UserId { get; set; }
		public ApplicationUsers applicationUsers { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
		
	}
}
