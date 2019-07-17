using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaEntities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public long phoneNumber { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }


    }
}
