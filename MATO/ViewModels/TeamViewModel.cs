using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class TeamViewModel
    {
        public string Name { get; set; }

        public ClubViewModel Club { get; set; }

        public ICollection<ClubMemberViewModel> TeamMembers { get; set; }

        public ICollection<TeamCoachViewModel> TeamCoachs { get; set; }
    }
}
