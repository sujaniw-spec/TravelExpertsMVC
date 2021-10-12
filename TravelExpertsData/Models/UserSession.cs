using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Purpose:Create user seesion object
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsData.Models
{
    public class UserSession
    {
        private const string UserKey = "myuser"; //key use for session
        private const string UserId = "userid"; //id use for session
       
        private ISession session { get; set; }
        public UserSession(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Set the user session user object 
        /// </summary>
        /// <param name="customer">Customer object</param>
        public void SetMyUser(Customer customer)
        {
            session.SetObject(UserKey, customer);
            session.SetInt32(UserId, customer.CustomerId);
        }

        /// <summary>
        /// Get the user object
        /// </summary>
        /// <returns>customer object</returns>
        public Customer GetMyUser() =>
          session.GetObject<Customer>(UserKey) ?? new Customer();

        /// <summary>
        /// Get the customerId
        /// </summary>
        /// <returns>customer id</returns>
        public int GetMyCustId() => session.GetInt32(UserId) ?? -1;

        /// <summary>
        /// Remove the session
        /// </summary>
        public void RemoveMyUser()
        {
            session.Remove(UserKey);
            session.Remove(UserId);
        }
    }
}
