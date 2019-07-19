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
        public PizzaAppContext(DbContextOptions<PizzaAppContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }
        public DbSet<Topping> Toppings { get; set; }

    }
}

