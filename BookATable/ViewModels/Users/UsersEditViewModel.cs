using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Users
{
    public class UsersEditViewModel:BaseEntity
    {
        [Required(ErrorMessage = "Please input URL! It is required!")]
        public string ImgURL { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z.-_]+)$", ErrorMessage = "Username can consist of letters, dashes and underscores only!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(80, ErrorMessage = "Must be between 5 and 80 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z-]+)$", ErrorMessage = "First Name can consist of letters and dashes only!")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z-]+)$", ErrorMessage = "Last Name can consist of letters and dashes only!")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}