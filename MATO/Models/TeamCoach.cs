using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class TeamCoach
    {
        public Team Team { get; set; }
        public ClubMember Coach { get; set; }
    }
}
