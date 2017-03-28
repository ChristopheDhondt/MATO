using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class TeamMember
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int MemberId { get; set; }
        public ClubMember Member { get; set; }
    }
}
