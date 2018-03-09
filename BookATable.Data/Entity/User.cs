using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Entity
{
    public class User : BaseEntity
    {
        public string ImgURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string ValidationCode { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
