using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Users
{
    public class UsersDeleteViewModel:BaseEntity
    {
       [System.ComponentModel.DataAnnotations.Required]
        public string ImgURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}