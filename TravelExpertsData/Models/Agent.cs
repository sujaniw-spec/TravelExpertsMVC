using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelExpertsData.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Display(Name = "Agent ID")]
        public int AgentId { get; set; }
        [StringLength(20)]
        public string AgtFirstName { get; set; }
        [StringLength(5)]
        public string AgtMiddleInitial { get; set; }
        [StringLength(20)]
        public string AgtLastName { get; set; }
        [StringLength(20)]
        [Display(Name = "Agent Phone")]
        public string AgtBusPhone { get; set; }
        [StringLength(50)]

        [Display(Name = "Agent Email")]
        public string AgtEmail { get; set; }
        [StringLength(20)]
        public string AgtPosition { get; set; }

        [Display(Name = "Agency ID")]
        public int? AgencyId { get; set; }

        [ForeignKey(nameof(AgencyId))]
        [InverseProperty("Agents")]
        public virtual Agency Agency { get; set; }
        [InverseProperty(nameof(Customer.Agent))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
