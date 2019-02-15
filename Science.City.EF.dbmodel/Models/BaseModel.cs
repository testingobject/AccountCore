using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.EF.Models
{
	public abstract class BaseModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public bool IsActive { get; set; } = true;

		public DateTime CreatedOn { get; set; } = DateTime.Now;

		public DateTime ModifyOn { get; set; } = DateTime.Now;
	}
}
