using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaEntities;

namespace PizzaApp.Models
{
    public class PizzaAppContext : DbContext
    {
        public PizzaAppContext (DbContextOptions<PizzaAppContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaEntities.Customer> Customer { get; set; }

        public DbSet<PizzaEntities.Order> Order { get; set; }

        public DbSet<PizzaEntities.Pizza> Pizza { get; set; }

        public DbSet<PizzaEntities.PizzaTopping> PizzaTopping { get; set; }

        public DbSet<PizzaEntities.Topping> Topping { get; set; }
    }
}
