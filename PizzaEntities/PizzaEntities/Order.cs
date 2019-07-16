using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaEntities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public bool delivery { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}
