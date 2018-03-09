using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Reservations
{
    public class ReservationsDeleteViewModel:BaseEntity
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int PeopleCount { get; set; }
        public DateTime ReservationTime { get; set; }
        public string Comment { get; set; }
    }
}