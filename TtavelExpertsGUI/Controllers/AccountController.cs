using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelExpertsData.Models;

/*Purpose:Login Management
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsGUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl; // preserve to come back to this page
            }
            return View();
        }

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
                    session.SetMyUser(usr);
                    session.GetMyCustId();
                };

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usr.CustEmail),
                    new Claim("CustomerId", customerId.ToString()),
                  //  new Claim(ClaimTypes.Role, usr.CustomerId)
                };

             
                
                if (usr.CustomerId != null)// user is an owner                
                    customerId = usr.CustomerId;
                HttpContext.Session.SetInt32("CurrentOwner", customerId);
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies"); // authentication type: Cookies
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                // generate authentication cookie
                await HttpContext.SignInAsync("Cookies", principal);

                // if no return URl, go to the Index page of Rentals controller
                if (TempData["ReturnUrl"] != null)
                    return Redirect(TempData["ReturnUrl"].ToString());
                else
                    return RedirectToAction("Index", "Package");
            }
        }//LoginAsync


        public async Task<IActionResult> LogoutAsync()
        {
            // remove the authentication cookie
            await HttpContext.SignOutAsync("Cookies");
            HttpContext.Session.SetInt32("CurrentUser", 0);// no current owner
            var session = new UserSession(HttpContext.Session);
            session.RemoveMyUser();
            return RedirectToAction("Index", "Package");
        }// LogoutAsync

        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

    }
}
