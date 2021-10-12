 using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.Models;

/*Purpose: Package buying process - display packages in the main page and go to description. allows to buy package.
 * Author:Sujani Wijesundera
 */

namespace TravelExpertsGUI.Controllers
{
    public class PackageController : Controller
    {
        private static Random random = new Random(); // to generate random string.

        /// <summary>
        /// Get all packages and display in the main page.
        /// </summary>
        /// <returns>lview with list</returns>
        // GET: PackageController 
        /*Display all packages
         */
        public ActionResult Index()
        {
            List<Package> list = PackageManager.GetAllPackages();
            return View(list);
        }


        /// <summary>
        /// Get the detail view of the package
        /// </summary>
        /// <param name="id">package id</param>
        /// <returns></returns>
        // GET: PackageController/Details/5

        /*Display details of the selected package
       */
        public ActionResult Details(int id)
        {
                
            Package package = PackageManager.GetPackageDetails(id);//get the package related to the package id
            return View(package);
        }

        /// <summary>
        /// Display view for buying package
        /// </summary>
        /// <param name="id">package id</param>
        /// <returns></returns>
        // GET: PackageController/Create
        [Authorize] //need login first to do the booking
        /*
         Package buying interface
         */
        [HttpGet]
        public ActionResult BuyPackage(int id)
        {
          //  List<Product> products = PackageManager.GetAllProducts();//get all the products
            Package package = PackageManager.GetPackageDetails(id);//get the detail of the package
                      
            List<TripType> tripTypes = PackageManager.GetAllTripTypes();//get all trip types
          //  ViewBag.Products = products;
            ViewBag.Package = package;//add to the view bag
            ViewBag.TripTypes = tripTypes;            
            return View();
        }

        /// <summary>
        /// Buy package send to the database booking and booking details
        /// </summary>
        /// <param name="bookingVM">model view for booking and booking details</param>
        /// <returns>return the view with booking recipt</returns>
        [HttpPost]
        public ActionResult BuyPackage(BookingBookingDetailsModelView bookingVM)
        {
            try
            {
                //Create a booking
                int? customerId = HttpContext.Session.GetInt32("CurrentOwner");//get the session
                if (customerId == null && User != null && User.Identity != null && User.Identity.Name != null)//if session is null get the cookie identity name
                {
                    customerId = CustomerManager.GetCustomerId(User.Identity.Name.ToString());//pass the email and get the customerid.
                }
                //create a new booking assign values
                Booking booking = new Booking();
                booking.BookingDate = DateTime.Today;
                booking.BookingNo = RandomString(5); // random string for booking number
                booking.CancelFlag = 0; //Not cancelled default
                booking.CustomerId = customerId;
                booking.PackageId = bookingVM.PackageId;
                booking.TravelerCount = bookingVM.TravelerCount;

                double? travlCount = booking.TravelerCount; //travel count assign to a variable
                booking.TripTypeId = bookingVM.TripTypeId;
                PackageManager.AddCustomerBooking(booking); //add to booking

                //Create a new booking details and assign values
                int productSuppid = PackageManager.GetProductSupplier(bookingVM.PackageId).ProductSupplierId;
                BookingDetail bookingDetails = new BookingDetail();
                decimal tvCount = Convert.ToDecimal(travlCount); //Travelcount convert ot decimal. B/C BasePrice is decimal
                bookingDetails.BasePrice = bookingVM.BasePrice * tvCount; //TravelCount * Base Price
                bookingDetails.BookingId = booking.BookingId;
                bookingDetails.TripStart = bookingVM.TripStart;
                bookingDetails.TripEnd = bookingVM.TripEnd;
                bookingDetails.AgencyCommission = bookingVM.AgencyCommission;
                bookingDetails.ProductSupplierId = productSuppid;
                PackageManager.AddCustomerBookingDetails(bookingDetails); //add to booking details

                ViewBag.BookingId = booking.BookingId; //assign booking id to display the receipt
                bookingVM.BasePrice = bookingDetails.BasePrice;
            }
            catch (Exception)
            {
                TempData["Message"] = "System error. Please try again.";
                return RedirectToAction(nameof(Index));
            }
            return View("BuyPackageReceipt", bookingVM); // return the booking receipt
        }



        /// <summary>
        /// Generate random string for booking number
        /// </summary>
        /// <param name="length">lenght of the random string</param>
        /// <returns>random string</returns>
        public static string RandomString(int length)
        {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }//class end
}
