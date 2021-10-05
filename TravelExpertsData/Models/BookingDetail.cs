using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelExpertsData.Models
{
    [Index(nameof(FeeId), Name = "Agency Fee Code")]
    [Index(nameof(BookingId), Name = "BookingId")]
    [Index(nameof(BookingId), Name = "BookingsBookingDetails")]
    [Index(nameof(ClassId), Name = "ClassesBookingDetails")]
    [Index(nameof(RegionId), Name = "Dest ID")]
    [Index(nameof(RegionId), Name = "DestinationsBookingDetails")]
    [Index(nameof(FeeId), Name = "FeesBookingDetails")]
    [Index(nameof(ProductSupplierId), Name = "ProductSupplierId")]
    [Index(nameof(ProductSupplierId), Name = "Products_SuppliersBookingDetails")]
    public partial class BookingDetail
    {
        [Key]
        public int BookingDetailId { get; set; }

        [Display(Name = "Itinerary No")]
        public double? ItineraryNo { get; set; }


        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        [Display(Name ="Start Date")]
        public DateTime? TripStart { get; set; }


        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        [Display(Name ="End Date")]
        public DateTime? TripEnd { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(255)]
        public string Destination { get; set; }
        [Column(TypeName = "money")]

        
        [DataType(DataType.Currency)]
        [Display(Name = "Base Price")]
        public decimal? BasePrice { get; set; }
        [Column(TypeName = "money")]

        [DataType(DataType.Currency)]
        [Display(Name = "Agency Commission")]
        public decimal? AgencyCommission { get; set; }

        [Display(Name = "Booking Id")]
        public int? BookingId { get; set; }
        [StringLength(5)]

        [Display(Name = "Region Id")]
        public string RegionId { get; set; }
        [StringLength(5)]

        [Display(Name = "Class Id")]
        public string ClassId { get; set; }
        [StringLength(10)]

        [Display(Name = "Fee Id")]
        public string FeeId { get; set; }

        [Display(Name = "Product Supplier Id")]
        public int? ProductSupplierId { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty("BookingDetails")]
        public virtual Booking Booking { get; set; }
        [ForeignKey(nameof(ClassId))]
        [InverseProperty("BookingDetails")]
        public virtual Class Class { get; set; }
        [ForeignKey(nameof(FeeId))]
        [InverseProperty("BookingDetails")]
        public virtual Fee Fee { get; set; }
        [ForeignKey(nameof(ProductSupplierId))]
        [InverseProperty(nameof(ProductsSupplier.BookingDetails))]
        [Display(Name = "Poduct Supplier")]
        public virtual ProductsSupplier ProductSupplier { get; set; }
        [ForeignKey(nameof(RegionId))]
        [InverseProperty("BookingDetails")]
        public virtual Region Region { get; set; }

    }
}
