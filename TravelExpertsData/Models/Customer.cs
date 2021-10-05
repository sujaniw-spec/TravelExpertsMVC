using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelExpertsData.Models
{
    [Index(nameof(AgentId), Name = "EmployeesCustomers")]
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CreditCards = new HashSet<CreditCard>();
            CustomersRewards = new HashSet<CustomersReward>();
        }

        [Key]
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string CustFirstName { get; set; }
        [Required]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string CustLastName { get; set; }
        [Required]
        [StringLength(75)]
        [Display(Name = "Address")]
        public string CustAddress { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "City")]
        public string CustCity { get; set; }
        [Required]
        [StringLength(2)]
        [Display(Name = "Province")]
        public string CustProv { get; set; }
        [Required]
        [StringLength(7)]
        [Display(Name = "Postal Code")]
        public string CustPostal { get; set; }
        [StringLength(25)]

        [Display(Name = "Country")]
        public string CustCountry { get; set; }
        [StringLength(20)]

        [Display(Name = "Home Phone")]
        public string CustHomePhone { get; set; }
        [Required]
        [StringLength(20)]

        [Display(Name = "Business Phone")]
        public string CustBusPhone { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string CustEmail { get; set; }
        [StringLength(12)]
        public string CustPassword { get; set; }

        [Display(Name = "Agent Id")]
        public int? AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        [InverseProperty("Customers")]
        public virtual Agent Agent { get; set; }
        [InverseProperty(nameof(Booking.Customer))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(CreditCard.Customer))]
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        [InverseProperty(nameof(CustomersReward.Customer))]
        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
}
