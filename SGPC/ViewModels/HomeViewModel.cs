using Microsoft.ApplicationInsights.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SGPC.Resources;

namespace SGPC.ViewModels
{
	public class HomeViewModel
	{
		[Display(Name = "Welcome", ResourceType = typeof(Resources.Resource))]
		public string Title { get; set; }
        [Display(Name = "WorkingAs", ResourceType = typeof(Resources.Resource))]
        public string WorkingAs { get; set; }
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }
        [Display(Name = "MobileNo", ResourceType = typeof(Resources.Resource))]
        public string MobileNo { get; set; }
        [Display(Name = "ReferBy", ResourceType = typeof(Resources.Resource))]
        public string ReferBy { get; set; }
    }
}
