using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.Models;


/* Purpose:Register new account
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsGUI.Controllers
{
    public class RegisterController : Controller
    {
        // GET: RegisterController
        public ActionResult Register()
        {
            return View();
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        // POST: RegisterController/Create
        //Register new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            try
            {
              //bool isExists = IsAlreadyExistEmail(customer.CustEmail);
                Customer newCustomer = new Customer();
                newCustomer.CustFirstName = customer.CustFirstName;
                newCustomer.CustLastName = customer.CustLastName;
                newCustomer.CustEmail = customer.CustEmail;
                newCustomer.CustPassword = customer.CustPassword;
                newCustomer.CustAddress = "N/A";
                newCustomer.CustCity = "N/A";
                newCustomer.CustProv = "-";
                newCustomer.CustPostal = "N/A";
                newCustomer.CustBusPhone = "N/A";
                newCustomer.AgentId = 1;
                RegisterManager.RegisterNewUser(newCustomer);

                return View("RegisterSuccess", newCustomer);
            }
            catch(Exception e)
            {
                TempData["Message"] = $"Error in Registration. Please Try again!";
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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


        /// <summary>
        /// Email Address Validation
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns>Return true or false</returns>
        public bool IsAlreadyExistEmail(string CustEmail)
        {
            // Customer customer = new Customer();
            Customer customer = UserManager.GetCustomerWithExistingingEmail(CustEmail);
            bool status;

            if (customer != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return status;

        }
    }
}

