using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public  class ShippingDetails
    {
        [Required(ErrorMessage ="Please enter your Name")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name="Your first address")]
        public string Line1 { get; set; }
        [Display(Name = "Your secound address")]
        public string Line2 { get; set; }
        [Display(Name = "Your email address")]
        
        [RegularExpression("^([0-9a-zA-Z]([-.w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-w]*[0-9a-zA-Z].)+[a-zA-Z]{2,9})$")]
        [Required(ErrorMessage = "Your email is wrong type")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your Country")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
