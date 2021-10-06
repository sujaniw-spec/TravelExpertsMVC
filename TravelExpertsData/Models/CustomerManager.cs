using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TravelExpertsData.Models
{

    /* Purpose:Customer view and modify package information
     * Author: Sujani Wijesundera
     */
    public static class CustomerManager
    {

        //Get my bookings list
        public static List<Booking> GetMyPackages(int? id)
        {
            List<Booking> bookings = null;
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                bookings = db.Bookings.Where(b => b.CustomerId == id && b.PackageId != null).Include(b => b.BookingDetails).Include(b=> b.Package).ToList();
            }
            return bookings;
        }

        /// <summary>
        /// Get booking by ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>Booking object</returns>
        public static Booking GetBooking(int id)
        {
            Booking booking;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                booking = db.Bookings.FirstOrDefault(b => b.BookingId == id);
            }
            return booking;
        }

        /// <summary>
        /// Cancel booking by ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns></returns>
        public static void CancelBooking(int id)
        {
            Booking booking;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                booking = db.Bookings.FirstOrDefault(b => b.BookingId == id);
                booking.CancelFlag = 1;
                db.SaveChanges();
            }
            //return booking;
        }

        /// <summary>
        /// Cancel booking by ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns></returns>
        public static void UpdateBooking(int id, Booking booking)
        {
            Booking oldBokking;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                oldBokking = db.Bookings.FirstOrDefault(b => b.BookingId == id);
                oldBokking.TravelerCount = booking.TravelerCount;
                db.SaveChanges();
            }
            //return booking;
        }


        /// <summary>
        /// Get Customer for given email
        /// </summary>
        /// <param name="email">email of the customer</param>
        /// <returns>Returns a custId</returns>
        public static int GetCustomerId(string email)
        {
            Customer customer = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                customer = db.Customers.Where(c=> c.CustEmail==email).FirstOrDefault();
            }
            return customer.CustomerId;
        }
    }
}
