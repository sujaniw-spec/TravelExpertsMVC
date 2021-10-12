using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelExpertsData.Models;

/*Purpose:Login Management - session/cookie
 * Author:Sujani Wijesundera
 */

namespace TravelExpertsGUI.Controllers
{

    //display login page
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl; // preserve to come back to this page
            }
            else
            {
                TempData["ReturnUrl"] = null; //if the url is null still temp data preseve of previous. so make it null
            }
            return View();
        }

        /// <summary>
        /// Check the login is correct. Make httpsession and persistance cookie
        /// </summary>
        /// <param name="user">Customer object</param>
        /// <returns>return url</returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer user)
        {
            Customer usr = UserManager.Authenticate(user.CustEmail, user.CustPassword);
            if (usr == null) // not authenticated
            {
                // TO DO: add message (with TempData)
                return View();// stay on the same page
            }
            else // authenticated
            {
                var session = new UserSession(HttpContext.Session);
                 HttpContext.Session.SetInt32("CurrentUser", usr.CustomerId);

                int customerId = 0;// owner Id 0 means the manager
                customerId = usr.CustomerId;
                var model = new Customer();
                {
                    session.SetMyUser(usr); //set the customer object to session
                    session.GetMyCustId(); //get the customer id from session
                };

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usr.CustEmail),//set the email to claim
                    new Claim("CustomerId", customerId.ToString()), // set the customer id
                };

             
                
                if (usr.CustomerId != null)// user is an owner                
                    customerId = usr.CustomerId;
                HttpContext.Session.SetInt32("CurrentOwner", customerId); //set the customer id to current owner
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies"); // authentication type: Cookies
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                // generate authentication cookie
                await HttpContext.SignInAsync("Cookies", principal);

                // if no return URl, go to the Index page of Rentals controller
                if (TempData["ReturnUrl"] != null)
                {
                    string returnUrl = TempData["ReturnUrl"].ToString();
                    return Redirect(returnUrl);
                }
                else
                    return RedirectToAction("Index", "Package"); //if no preserve url go to the page index
            }
        }//end LoginAsync


        /// <summary>
        /// Logout asyncronasley
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogoutAsync()
        {
            // remove the authentication cookie
            await HttpContext.SignOutAsync("Cookies"); //signout from cookie
            HttpContext.Session.SetInt32("CurrentUser", 0);//no current owner
            var session = new UserSession(HttpContext.Session);
            session.RemoveMyUser();//remove session
            return RedirectToAction("Index", "Package"); //redirect to home page
        }// LogoutAsync


        /// <summary>
        ///unauthorized access returns to this page
        /// </summary>
        /// <returns></returns>
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

    }
}
