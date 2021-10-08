using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData.Models
{
    public class AgencyAgentsModelView
    {
        public List<Agent> Agents { get; set; }
        public List<Agency> Agencies { get; set; }

    }
}
