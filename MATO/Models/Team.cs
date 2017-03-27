using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class Team
    {
        public int id { get; set; }

        public string Name { get; set; }

        public Club Club { get; set; }

        public ICollection<ClubMember> TeamMembers { get; set; }

        public ICollection<TeamCoach> TeamCoachs { get; set; }
    }
}
