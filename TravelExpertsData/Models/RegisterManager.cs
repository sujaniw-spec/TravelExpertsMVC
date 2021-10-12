using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Purpose:Manage user registration. Add new user to the database and check the email address already exists in the database
 * Author:Sujani Wijesundera
 * date:06/10/2021
 */
namespace TravelExpertsData.Models
{
    public static class RegisterManager
    {

        /// <summary>
        /// New user rregistration
        /// </summary>
        /// <param name="customer">Customer object ot send the db</param>
        public static void RegisterNewUser(Customer customer)
        {
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Add(customer);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all the customers to check unique email address.
        /// </summary>
        /// <returns>Return customer</returns>
        public static Customer GetCustomerWithExistingingEmail(string custemail)
        {
            Customer customer = new Customer();
            List<Customer> list;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                list = db.Customers.ToList();
            }
                
            return customer;
        }
    }
}
