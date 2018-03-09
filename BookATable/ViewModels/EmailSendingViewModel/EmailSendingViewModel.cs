using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Web.ViewModels.EmailSendingViewModel
{
    public class EmailSendingViewModel
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*@gmail.com$",  ErrorMessage = "Email Format is wrong")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Comment { get; set; }
    }
}