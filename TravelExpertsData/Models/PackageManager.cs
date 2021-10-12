using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Purpose: Helpto create a booking view and send booking data to the database
 * Author: Sujani Wijesundera
 */
namespace TravelExpertsData.Models
{
    public static class PackageManager
    {
        /// <summary>
        /// Get packages where end date is greater than or equals today
        /// </summary>
        /// <returns>List of packages</returns>
        public static List<Package> GetAllPackages()
        {
            List<Package> listPackages = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                listPackages = db.Packages.Where(p => p.PkgEndDate >= DateTime.Now).ToList();
            }
            return listPackages;
        }

        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns>List of products</returns>
        public static List<Product> GetAllProducts()
        {
            List<Product> listProducts = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                listProducts = db.Products.ToList();
            }
            return listProducts;
        }


        /// <summary>
        /// Get All triptypes
        /// </summary>
        /// <returns>List of trip types</returns>
        public static List<TripType> GetAllTripTypes()
        {
            List<TripType> listTripTypes = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                listTripTypes = db.TripTypes.ToList();
            }
            return listTripTypes;
        }

        /// <summary>
        /// Add customer booking to the table
        /// </summary>
        /// <param name="booking">Booking object</param>
        public static void AddCustomerBooking(Booking booking)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Add(booking);
                db.SaveChanges();
            }
        }

       /// <summary>
       /// Add record to the booking details table
       /// </summary>
       /// <param name="bookingDetail">BookingDetail object</param>
        public static void AddCustomerBookingDetails(BookingDetail bookingDetail)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Add(bookingDetail);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Get  the product supplier relavant to the package
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Product supplier object</returns>
        public static PackagesProductsSupplier GetProductSupplier(int? id)
        {
            PackagesProductsSupplier prodsup = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {

                prodsup = db.PackagesProductsSuppliers.Where(pp => pp.PackageId == id).FirstOrDefault();

            }
            return prodsup;
        }

        /// <summary>
        /// Get package details for a given package
        /// </summary>
        /// <param name="id">ID of the package</param>
        /// <returns>Returns a package</returns>
        public static Package GetPackageDetails(int id)
        {
            Package package = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                package = db.Packages.Find(id);
            }
            return package;
        }

    }//class end
}
