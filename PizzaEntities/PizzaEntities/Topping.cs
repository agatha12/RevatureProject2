using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace PizzaEntities
{
    [DataContract]
    public class Topping
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DataMember]
        public int id { get; set; }
        [Required]
        [DataMember]
        public string name { get; set; }
        [Required]
        [DataMember]
        public decimal price { get; set; }

    }
}
