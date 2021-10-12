using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Purpose:View model class for combine of agents and agencies class. This view use for display contact us page.
 * Author: Sujani Wijesundera
 * reference:https://www.c-sharpcorner.com/article/managing-data-with-viewmodel-in-asp-net-mvc/
 */
namespace TravelExpertsData.Models
{
    public class AgencyAgentsModelView
    {
        public List<Agent> Agents { get; set; } //List of agents
        public List<Agency> Agencies { get; set; } //List of agencies

    }
}
