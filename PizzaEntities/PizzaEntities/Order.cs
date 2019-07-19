using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PizzaEntities
{
    [DataContract]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public int CustomerId { get; set; }
        [Required]
        [DataMember]
        public DateTime date { get; set; }
        [Required]
        [DataMember]
        public bool delivery { get; set; }
        [Required]
        [DataMember]
        public string status { get; set; }
        [Required]
        [DataMember]
        public decimal price { get; set; }
    }
}
