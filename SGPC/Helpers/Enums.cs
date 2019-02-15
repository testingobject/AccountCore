using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGPC.Helpers
{
    public class Enums
    {
        public enum Role
        {
            Admin = 1,
            User = 2
        }
        public enum EnumTicketStatus
        {
            [Display(Description = "Approved", ResourceType = typeof(Resources.Resource))]
            Approved = 1,
            [Display(Description = "Rejected", ResourceType = typeof(Resources.Resource))]
            Rejected = 2,
            [Display(Description = "Hold", ResourceType = typeof(Resources.Resource))]
            Hold = 3
        }
    }
}
