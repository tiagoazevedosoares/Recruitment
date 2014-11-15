using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recruitment.Web.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string NewPasswordConfirmation { get; set; }
    }
}