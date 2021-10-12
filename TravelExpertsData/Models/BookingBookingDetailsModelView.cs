using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Purpose: To get the view of Booking and Booking details entities. To create a booking and display booking receipt.
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsData.Models
{
    public  class BookingBookingDetailsModelView
    {
        [Required]
        [Range(1, 20, ErrorMessage = "Travellers must not be zero or more than 20")]
        [Display(Name = "Traveler Count")]
        public double? TravelerCount { get; set; } //travel count of booking table
        public int? CustomerId { get; set; } //customer id of customer table

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Bookings")] 
        public virtual Customer Customer { get; set; } //customer object
        public int? PackageId { get; set; } //package id from package table

        [Required]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")] //trip start date from booking details
        [Display(Name = "Trip Start")]
        public DateTime? TripStart { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")] 
        [Display(Name = "Trip End")]
        public DateTime? TripEnd { get; set; } //trip end date from booking details
        [StringLength(255)]
        public string Destination { get; set; } //destination of booking
        [Column(TypeName = "money")]

        [Display(Name = "Price")] 
        [DataType(DataType.Currency)]
        public decimal? BasePrice { get; set; } //base price
        [Column(TypeName = "money")]
        [Display(Name = "Agency Commission")] 
        public decimal? AgencyCommission { get; set; }//commision

        [Required]
        public string TripTypeId { get; set; } //trip type id

        [ForeignKey(nameof(PackageId))] //package id
        [InverseProperty("Bookings")]
        public virtual Package Package { get; set; } //Package


        [ForeignKey(nameof(TripTypeId))]
        [InverseProperty("Bookings")]
        public virtual TripType TripType { get; set; } //trip type

        public int? ProductSupplierId { get; set; } 

        [ForeignKey(nameof(ProductSupplierId))]
        [InverseProperty(nameof(ProductsSupplier.BookingDetails))]
        public virtual ProductsSupplier ProductSupplier { get; set; }


    }
}
