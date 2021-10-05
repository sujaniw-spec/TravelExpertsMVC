using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelExpertsData.Models;

namespace TravelExpertsGUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl; // preserve to come back to this page
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
                int ownerId = 0;// owner Id 0 means the manager
              //  if (usr.CustomerId!=null)// user is an owner                
                 //   ownerId = (int)usr.OwnerId;
                HttpContext.Session.SetInt32("CurrentUser", usr.CustomerId);

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usr.CustEmail),
                    new Claim("CustFirstName", usr.CustFirstName),
                  //  new Claim(ClaimTypes.Role, usr.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies"); // authentication type: Cookies
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                // generate authentication cookie
                await HttpContext.SignInAsync("Cookies", principal);

                // if no return URl, go to the Index page of Rentals controller
                if (TempData["ReturnUrl"] != null)
                    return Redirect(TempData["ReturnUrl"].ToString());
                else
                    return RedirectToAction("Index", "Rentals");
            }
        }//LoginAsync


        public async Task<IActionResult> LogoutAsync()
        {
            // remove the authentication cookie
            await HttpContext.SignOutAsync("Cookies");
            HttpContext.Session.SetInt32("CurrentUser", 0);// no current owner
            return RedirectToAction("Index", "Package");
        }// LogoutAsync

        public IActionResult AccessDenied()
        {
            return View();
        }


        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
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

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
    }
}
