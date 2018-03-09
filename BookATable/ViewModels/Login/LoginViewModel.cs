using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Login
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(160, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 160")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]

        public string Password { get; set; }
    }
}