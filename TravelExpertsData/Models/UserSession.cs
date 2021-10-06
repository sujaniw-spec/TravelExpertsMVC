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
        private const string UserKey = "myuser";
        private const string UserId = "userid";
       
        private ISession session { get; set; }
        public UserSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyUser(Customer customer)
        {
            session.SetObject(UserKey, customer);
            session.SetInt32(UserId, customer.CustomerId);
        }

        public Customer GetMyUser() =>
          session.GetObject<Customer>(UserKey) ?? new Customer();
        public int GetMyCustId() => session.GetInt32(UserId) ?? -1;


        // public string GetActiveDiv() => session.GetString(MovieKey);

        public void RemoveMyUser()
        {
            session.Remove(UserKey);
            session.Remove(UserId);
        }
    }
}
