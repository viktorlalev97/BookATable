using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Restaurants
{
    public class RestaurantsDeleteViewModel: BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public DateTime OpenHour { get; set; }
        public DateTime CloseHour { get; set; }
    }
}