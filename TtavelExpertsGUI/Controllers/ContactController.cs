using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData.Models;


/*Purpose: Contact Us - retrive Agenices and agency contacts
 * Author: Sujani Wijesundera
 */
namespace TravelExpertsGUI.Controllers
{
    public class ContactController : Controller
    {
        // GET: ContactController

        /// <summary>
        /// Display agents and agencies in the contact us index page
        /// </summary>
        /// <returns>View with agency view model</returns>
        public ActionResult Index()
        {
            List<Agent> agents = ContactUsManager.GetAgents(); //get all agents
            List<Agency> agencies = ContactUsManager.GetAgencies(); //get all agencies

            var AgencyAgentsModelView = new AgencyAgentsModelView //create a new object of view model
            {
                Agents = agents, //set agents list
                Agencies = agencies //set agencies list
            };
           
            return View(AgencyAgentsModelView); //returns the view model
        }
    }
}
