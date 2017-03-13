using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Brand is required!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Type is required!")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Vintage is required!")]
        public int Vintage { get; set; }
        //[Required(ErrorMessage = "Manifacture Time is required!")]
        public int ManifactureTime { get; set; }
        //[Required(ErrorMessage = "Condition is required!")]
        public string Condition { get; set; }
        [Required(ErrorMessage = "Owner Number is required!")]
        public int OwnerNumber { get; set; }


        public int CarDealerId { get; set; }
        public virtual CarDealer CarDealer { get; set; }
    }
}