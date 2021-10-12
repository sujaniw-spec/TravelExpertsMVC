using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.Models;


/* Purpose:Register new user account
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsGUI.Controllers
{
    public class RegisterController : Controller
    {

        /// <summary>
        /// Returns the view to user registration
        /// </summary>
        /// <returns></returns>
        // GET: RegisterController
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register new user and send data to the database
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <returns>View with success message or if error return to the same page</returns>         
        // POST: RegisterController/Create
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
                    newCustomer.CustAddress = "N/A"; //no values taken from the interface
                    newCustomer.CustCity = "N/A";
                    newCustomer.CustProv = "-";
                    newCustomer.CustPostal = "N/A";
                    newCustomer.CustBusPhone = "N/A";
                    newCustomer.AgentId = 1;
                    if(customer.CustPassword == null || customer.CustPassword.Trim().Length==0 || customer.CustPassword.Length<5)
                {
                    return View();
                }
                    RegisterManager.RegisterNewUser(newCustomer);

                    return View("RegisterSuccess", newCustomer);
                //}
            }
            catch(Exception e)
            {
                TempData["Message"] = $"Error in Registration. Please Try again!";
                return View();
            }
            //return View();
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

