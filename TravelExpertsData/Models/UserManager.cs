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
                user = db.Customers.SingleOrDefault(u => u.CustEmail == email && u.CustPassword == password);
            }
                
            return user;
        }
    }//class end
}
