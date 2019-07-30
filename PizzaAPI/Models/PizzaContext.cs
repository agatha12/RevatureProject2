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

        // Function to get individual price 
        //using toppings first then accounting for size
        public async Task<decimal> getPizzaPriceAsync(int givenPizzaId)
        {
            decimal totalPrice = 0m;
            var toppings = PizzaToppings.Where(n => n.pizzaId == givenPizzaId);
            foreach(PizzaTopping topping in toppings)
            {
                // Query database and add all topping prices to pizza
                var toppingObject = await Toppings.FirstOrDefaultAsync(n => n.id == topping.toppingId);
                totalPrice += toppingObject.price;
            }
            var ourPizza = await Pizza.SingleOrDefaultAsync(n => n.id == givenPizzaId);
            switch (ourPizza.size)
            {
                case "small":
                    totalPrice += 8.00m;
                    break;
                case "medium":
                    totalPrice += 12.00m;
                    break;
                case "large":
                    totalPrice += 16.00m;
                    break;
                case "special":
                    totalPrice += 10.00m;
                    break;
                default:
                    break;
            }
            return totalPrice;
        }
        // Function to get the total order price
        // using aforementioned getPizzaPriceAsync
        // as a helper function
        public async Task<decimal> getTotalOrderPriceAsync(int givenOrderId)
        {
            decimal totalPrice = 0m;
            var pizzasInOrder = Pizza.Where(n => n.OrderId == givenOrderId);
            foreach(Pizza pizza in pizzasInOrder)
            {
                totalPrice += await getPizzaPriceAsync(pizza.id);
            }
            return totalPrice;
        }

    }
}

