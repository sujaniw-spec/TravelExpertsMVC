using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelExpertsData.Models;


/* Purpose:Manage controls of customer packages (update and cancel package)
 * Author: Sujani Wijesundera
 */
namespace TravelExpertsGUI.Controllers
{
    public class CustomerController : Controller
    {
        /// <summary>
        /// Display all packages related to the customer
        /// </summary>
        /// <returns>view with customer packages list</returns>
        // GET: CustomerController
        [Authorize] //only person who login can view their packages
        public ActionResult Index()
        {
            int? customerId = HttpContext.Session.GetInt32("CurrentOwner"); //get the session
            if (customerId == null && User !=null && User.Identity != null && User.Identity.Name != null)//if session is null get the cookie identity
            {
                customerId = CustomerManager.GetCustomerId(User.Identity.Name.ToString());//pass customer email and get the customer id
            }
            List<Booking> bookingList = CustomerManager.GetMyPackages(customerId); //get the booking list of customer
            return View(bookingList); //return view with booking list
        }


        /// <summary>
        /// Display booking for editing
        /// </summary>
        /// <param name="id">booking id</param>
        /// <returns>booking view</returns>
        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            Booking booking = CustomerManager.GetBooking(id);//get the booking for booking id
            return View(booking);
        }



        /// <summary>
        /// Send the edited booking to the database
        /// </summary>
        /// <param name="id">booking id</param>
        /// <param name="booking">booking object</param>
        /// <returns>If success goes to the index page of list of packages of the customer. If fails return to the same view</returns>
        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Booking booking)
        {
            try
            {
                CustomerManager.UpdateBooking(id, booking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(booking);
            }
        }


        /// <summary>
        /// Cancel the package
        /// </summary>
        /// <param name="id">booking id</param>
        /// <returns>return the booking view relavant to the id</returns>
        // GET: CustomerController/Cancel/5
        public ActionResult Cancel(int id)
        {
            Booking booking = CustomerManager.GetBooking(id); //get booking for booking id
            return View(booking);
        }



        /// <summary>
        /// Cancel the booking. update database.
        /// </summary>
        /// <param name="id">booing id</param>
        /// <param name="collection">collection</param>
        /// <returns>redirect othe list of bookings</returns>
        // POST: CustomerController/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id, IFormCollection collection)
        {
            try
            {
                CustomerManager.CancelBooking(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
