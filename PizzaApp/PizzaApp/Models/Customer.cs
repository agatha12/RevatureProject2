using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//using BankingA.Models.BankingA.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApp.Models
{
    public class Customer : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

    }
   
}
