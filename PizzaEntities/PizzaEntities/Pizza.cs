using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaEntities
{
    public class Pizza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public string sauce { get; set; }
        [Required]
        public string crust { get; set; }
    }
}
