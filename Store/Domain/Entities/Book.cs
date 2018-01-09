using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
  public  class Book
    {
        [HiddenInput(DisplayValue =false)]
        [Display(Name = "ID")]
        public int BookId { get;set;}
        [Display(Name="Name")]
        [Required(ErrorMessage ="Please,enter book name")]
        public string Name { get; set; }
        [Display(Name = "Author")]
        [Required(ErrorMessage = "Please,enter book Author")]
        public string Author { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please,enter book Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please,enter book genre")]
        public string Genre { get; set; }
        [Display(Name = "Price(USD")]
        [Required][Range(0.01,double.MaxValue,ErrorMessage = "Please,enter positive book price")]
        public decimal Price { get; set; }


    }
}
