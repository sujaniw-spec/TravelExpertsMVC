using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelExpertsData.Models
{
    [Index(nameof(CustomerId), Name = "BookingsCustomerId")]
    [Index(nameof(CustomerId), Name = "CustomersBookings")]
    [Index(nameof(PackageId), Name = "PackageId")]
    [Index(nameof(PackageId), Name = "PackagesBookings")]
    [Index(nameof(TripTypeId), Name = "TripTypesBookings")]
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        [Key]
        [Display(Name = "Booking Id")]
        public int BookingId { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Booking Date")]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        public DateTime? BookingDate { get; set; }
        [StringLength(50)]
        [Display(Name = "Booking No")]
        public string BookingNo { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Travellers must not be zero or more than 20")]
        [Display(Name = "Traveler Count")]
        public double? TravelerCount { get; set; }

        [Display(Name = "Customer Id")]
        public int? CustomerId { get; set; }
        [StringLength(1)]
        [Display(Name = "Trip Type Id")]
        public string TripTypeId { get; set; }

        [Display(Name = "Package Id")]
        public int? PackageId { get; set; }
        public int? CancelFlag { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Bookings")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(PackageId))]
        [InverseProperty("Bookings")]
        public virtual Package Package { get; set; }
        [ForeignKey(nameof(TripTypeId))]
        [InverseProperty("Bookings")]
        [Display(Name = "Trip Type")]
        public virtual TripType TripType { get; set; }
        [InverseProperty(nameof(BookingDetail.Booking))]
        [Display(Name = "Booking Details")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
