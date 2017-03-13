using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarDealer.Models;

namespace CarDealer.Context
{
    public class CarDealerContext : DbContext
    {
        public DbSet<Models.CarDealer> CarDealers { get; set; }

        public DbSet<Car> Cars { get; set; }

    }
}