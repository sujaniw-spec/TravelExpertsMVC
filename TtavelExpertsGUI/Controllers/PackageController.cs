using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.Models;

/*Purpose: Package buying process
 * Author:Sujani Wijesundera
 */

namespace TravelExpertsGUI.Controllers
{
    public class PackageController : Controller
    {
        private static Random random = new Random(); // to generate random string.

        // GET: PackageController 
        /*Display all packages
         */
        public ActionResult Index()
        {
            List<Package> list = PackageManager.GetAllPackages();
            return View(list);
        }

        // GET: PackageController/Details/5

        /*Display details of the selected package
       */
        public ActionResult Details(int id)
        {
                
            Package package = PackageManager.GetPackageDetails(id);
            return View(package);
        }


        [Authorize]
        // GET: PackageController/Create
        /*
         Package buying interface
         */
        [HttpGet]
        public ActionResult BuyPackage(int id)
        {
            List<Product> products = PackageManager.GetAllProducts();
            Package package = PackageManager.GetPackageDetails(id);
                      
            List<TripType> tripTypes = PackageManager.GetAllTripTypes();
            ViewBag.Products = products;
            ViewBag.Package = package;
            ViewBag.TripTypes = tripTypes;            
            return View();
        }

        /*
         Add selected package to the booking and booking details.
         */
        [HttpPost]
        public ActionResult BuyPackage(BookingBookingDetailsModelView bookingVM)
        {
            try
            {
                //Create a booking
                int? customerId = HttpContext.Session.GetInt32("CurrentOwner");
                if (customerId == null && User != null && User.Identity != null && User.Identity.Name != null)
                {
                    customerId = CustomerManager.GetCustomerId(User.Identity.Name.ToString());
                }

                Booking booking = new Booking();
                booking.BookingDate = DateTime.Today;
                booking.BookingNo = RandomString(5); // random string for booking number
                booking.CancelFlag = 0; //Not cancelled
                booking.CustomerId = customerId;//bookingVM.CustomerId;
                booking.PackageId = bookingVM.PackageId;
                booking.TravelerCount = bookingVM.TravelerCount;
                booking.TripTypeId = bookingVM.TripTypeId;
                PackageManager.AddCustomerBooking(booking);

                //Create a booking details
                int productSuppid = PackageManager.GetProductSupplier(bookingVM.PackageId).ProductSupplierId;
                BookingDetail bookingDetails = new BookingDetail();
                bookingDetails.BasePrice = bookingVM.BasePrice;
                bookingDetails.BookingId = booking.BookingId;
                bookingDetails.TripStart = bookingVM.TripStart;
                bookingDetails.TripEnd = bookingVM.TripEnd;
                bookingDetails.AgencyCommission = bookingVM.AgencyCommission;
                bookingDetails.ProductSupplierId = productSuppid;
                PackageManager.AddCustomerBookingDetails(bookingDetails);

                ViewBag.BookingId = booking.BookingId;
            }
            catch (Exception)
            {
                TempData["Message"] = "System error. Please try again.";
                return RedirectToAction(nameof(Index));
            }
            return View("BuyPackageReceipt", bookingVM); // return the booking receipt
        }

        //Generate random string for booking number
        public static string RandomString(int length)
        {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }//class end
}
