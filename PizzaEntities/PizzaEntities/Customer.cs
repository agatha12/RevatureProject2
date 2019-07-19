using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace PizzaEntities
{
    [DataContract]
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DataMember]
        public int id { get; set; }
        [Required]
        [DataMember]
        public string firstName { get; set; }
        [Required]
        [DataMember]
        public string lastName { get; set; }
        [Required]
        [DataMember]
        public string address { get; set; }
        [Required]
        [DataMember]
        public long phoneNumber { get; set; }
        [Required]
        [DataMember]
        public long creditCardNumber { get; set; }
        [Required]
        [DataMember]

        public string expDate { get; set; }
        [Required]
        [DataMember]
        public int cvc { get; set; }
        [Required]
        [DataMember]
        public string email { get; set; }
        [Required]
        [DataMember]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }



    }
}
