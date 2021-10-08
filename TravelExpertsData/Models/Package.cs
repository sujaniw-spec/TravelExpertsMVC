using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelExpertsData.Models
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSupplier>();
        }

        [Key]
        public int PackageId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string PkgName { get; set; }
        [Column(TypeName = "datetime")]

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        public DateTime? PkgStartDate { get; set; }
        [Column(TypeName = "datetime")]

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        public DateTime? PkgEndDate { get; set; }
        [StringLength(50)]

        [Display(Name = "Description")]
        public string PkgDesc { get; set; }
        [Column(TypeName = "money")]

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal PkgBasePrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? PkgAgencyCommission { get; set; }

        [InverseProperty(nameof(Booking.Package))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(PackagesProductsSupplier.Package))]
        public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }
    }
}
