using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarDealer.Models
{
    public class CarDealer
    {
        [Key]
        public int CarDealerId { get; set; }
        [Required(ErrorMessage = "Zip Code is required!")]
        [Range(1000, 9999, ErrorMessage = "Zip Code must be between 1000 and 9999")]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Car Park Number is required!")]
        public int CarParkNumber { get; set; }
        
        public List<Car> Cars { get; set; }
    }
}