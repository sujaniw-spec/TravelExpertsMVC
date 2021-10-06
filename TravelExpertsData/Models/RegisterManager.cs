using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData.Models
{
    public static class RegisterManager
    {

        public static void RegisterNewUser(Customer customer)
        {
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Add(customer);
                db.SaveChanges();
            }
        }
    }
}
