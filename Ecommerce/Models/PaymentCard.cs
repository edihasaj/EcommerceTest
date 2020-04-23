using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class PaymentCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Card Number")]        
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Card Name")] 
        public string CardName { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        [Display(Name = "Expiration Date")] 
        public DateTime ExpirationDate { get; set; }
    }
}
