using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Entity
{
    public class Reservation : BaseEntity
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int PeopleCount { get; set; }
        public DateTime ReservationTime { get; set; }
        public string Comment { get; set; }
        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
