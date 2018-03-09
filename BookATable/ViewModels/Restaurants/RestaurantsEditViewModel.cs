using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Restaurants
{
    public class RestaurantsEditViewModel: BaseEntity
    { 
        [Required(ErrorMessage = "Please input a name! It is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 20")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Name can consist of letters, spaces and dashes only!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input a address! It is required!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 40")]
        public string Address { get; set; }

        [RegularExpression(@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)\[\]]*$")]
        public string Phone { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Capacity { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime OpenHour { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CloseHour { get; set; }
    }
}