using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recruitment.Web.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}