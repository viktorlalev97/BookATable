using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Restaurants
{
    public class RestaurantsCreateViewModel
    {
        [Required]
        [StringLength(160, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 160")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)\[\]]*$")]
        public string Phone { get; set; }
        [Required]
        [Range(1, 150)]
        public int Capacity { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime OpenHour { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CloseHour { get; set; }

    }
}