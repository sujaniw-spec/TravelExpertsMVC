using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Purpose:User login and register managment
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsData.Models
{
    public static class UserManager
    {

        /// <summary>
        /// authenticates user base on email and password
        /// </summary>
        /// <param name="username">provided email</param>
        /// <param name="password">provided password</param>
        /// <returns>matching registered user on null if not found</returns>
        public static Customer Authenticate(string email, string password)
        {
            Customer user = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                user = db.Customers.SingleOrDefault(u => u.CustEmail == email.Trim() && u.CustPassword == password.Trim());
            }
                
            return user;
        }

        /// <summary>
        /// Get all the customers to check unique email address.
        /// </summary>
        /// <returns>Return customer</returns>
        public static Customer GetCustomerWithExistingingEmail(string custemail)
        {
            Customer customer = new Customer();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                customer = db.Customers.SingleOrDefault(c => c.CustEmail == custemail);
            }

            return customer;
        }

    }//class end
}
