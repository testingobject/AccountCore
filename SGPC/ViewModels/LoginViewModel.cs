using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGPC.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "UserName", ResourceType = typeof(Resources.Common))]
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "UserNameRequired")]

        public string UserName { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Common))]
        [Required(ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }
        
        public bool IsRemember { get; set; }
    }
}
