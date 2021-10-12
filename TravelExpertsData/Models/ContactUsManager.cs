using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

/*Purpose:Manage agencies and agent infomation
 * Author:Sujani Wijesundera
 */
namespace TravelExpertsData.Models
{
    public static class ContactUsManager
    {

        /// <summary>
        /// Retrive all agents
        /// </summary>
        /// <returns>List of agents</returns>
        public static List<Agent> GetAgents()
        {
            List<Agent> list = null;
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                list =db.Agents.ToList();
            }
            return list;
        }


        /// <summary>
        /// Get all the agencies
        /// </summary>
        /// <returns>returns all the agencies</returns>
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
