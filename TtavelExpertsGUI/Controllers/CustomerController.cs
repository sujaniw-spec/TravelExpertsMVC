using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.Models;


/* Purpose:Manage controls of customer packages
 * Author: Sujani Wijesundera
 */
namespace TravelExpertsGUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index(int id=104)
        {
            List<Booking> bookingList = CustomerManager.GetMyPackages(id);
            return View(bookingList);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            Booking booking = CustomerManager.GetBooking(id);
            return View(booking);
        }

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

        // GET: CustomerController/Cancel/5
        public ActionResult Cancel(int id)
        {
            Booking booking = CustomerManager.GetBooking(id);
            return View(booking);
        }

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
