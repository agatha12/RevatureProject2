using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace PizzaEntities
{
    [DataContract]
    public class PizzaTopping
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DataMember]
        public int id { get; set; }
        [Required]
        [DataMember]
        public int pizzaId { get; set; }
        [Required]
        [DataMember]
        public int toppingId { get; set; }
    }
}
