using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class TeamCoachViewModel
    {
        public TeamViewModel Team { get; set; }
        public ClubMemberViewModel Coach { get; set; }
    }
}
