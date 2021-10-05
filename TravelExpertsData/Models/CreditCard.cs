using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelExpertsData.Models
{
    [Index(nameof(CustomerId), Name = "CustomersCreditCards")]
    public partial class CreditCard
    {
        [Key]
        [Display(Name = "Credit Card ID")]
        public int CreditCardId { get; set; }
        [Required]
        [Column("CCName")]
        [StringLength(10)]
        [Display(Name = "Name")]
        public string Ccname { get; set; }
        [Required]
        [Column("CCNumber")]
        [StringLength(50)]
        [Display(Name = "Card Number")]
        public string Ccnumber { get; set; }
        [Column("CCExpiry", TypeName = "datetime")]
        [Display(Name = "Expiry Date")]
        public DateTime Ccexpiry { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CreditCards")]
        public virtual Customer Customer { get; set; }
    }
}
