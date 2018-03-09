using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATable.ViewModels.Reservations
{
    public class ReservationsEditViewModel:BaseEntity
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }

        [Required]
        [Range(1, 150)]
        public int PeopleCount { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationTime { get; set; }
        public string Comment { get; set; }
        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Restaurants { get; set; }
    }
}