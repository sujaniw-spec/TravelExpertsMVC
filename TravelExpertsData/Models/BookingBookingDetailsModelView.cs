using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Purpose: To get the view of Booking and Booking details entities
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsData.Models
{
    public  class BookingBookingDetailsModelView
    {
        [Required]
        [Range(1, 20, ErrorMessage = "Travellers must not be zero or more than 20")]
        [Display(Name = "Traveler Count")]
        public double? TravelerCount { get; set; }
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Bookings")]
        public virtual Customer Customer { get; set; }
        public int? PackageId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        [Display(Name = "Trip Start")]
        public DateTime? TripStart { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        [Display(Name = "Trip End")]
        public DateTime? TripEnd { get; set; }
        [StringLength(255)]
        public string Destination { get; set; }
        [Column(TypeName = "money")]

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal? BasePrice { get; set; }
        [Column(TypeName = "money")]
        [Display(Name = "Agency Commission")]
        public decimal? AgencyCommission { get; set; }

        [Required]
        public string TripTypeId { get; set; }

        [ForeignKey(nameof(PackageId))]
        [InverseProperty("Bookings")]
        public virtual Package Package { get; set; }


        [ForeignKey(nameof(TripTypeId))]
        [InverseProperty("Bookings")]
        public virtual TripType TripType { get; set; }

        public int? ProductSupplierId { get; set; }

        [ForeignKey(nameof(ProductSupplierId))]
        [InverseProperty(nameof(ProductsSupplier.BookingDetails))]
        public virtual ProductsSupplier ProductSupplier { get; set; }


    }
}
