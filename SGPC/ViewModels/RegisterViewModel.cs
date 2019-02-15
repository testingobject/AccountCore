using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGPC.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Common))]
        [Required(ErrorMessage = "Please Enter Name")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.Common))]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Common))]
        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        
        [Display(Name = "MobileNo", ResourceType = typeof(Resources.Common))]
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Common))]
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Password length 8 to 25 Character")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Common))]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
