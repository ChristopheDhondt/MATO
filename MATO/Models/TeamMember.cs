using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class TeamMember
    {
        public Team Team { get; set; }

        public ClubMember member { get; set; }
    }
}
