using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace PizzaEntities
{
    [DataContract]
    public class Pizza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DataMember]
        public int id { get; set; }
        [Required]
        [DataMember]
        public int OrderId { get; set; }
        [Required]
        [DataMember]
        public string size { get; set; }
        [Required]
        [DataMember]
        public string sauce { get; set; }
        [Required]
        [DataMember]
        public string crust { get; set; }
        //[NotMapped]
        //public List<Topping> toppings { get; set; }
    }
}
