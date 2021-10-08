using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

/*Purpose: Get agencies and agent infomation
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsData.Models
{
    public static class ContactUsManager
    {

        public static List<Agent> GetAgents()
        {
            List<Agent> list = null;
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                list =db.Agents.ToList();
            }
            return list;
        }



        public static List<Agency> GetAgencies()
        {
            List<Agency> list = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                list = db.Agencies.ToList();
            }
            return list;
        }

    }
}
