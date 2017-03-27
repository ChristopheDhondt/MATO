using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class TeamMemberViewModel
    {
        public TeamViewModel Team { get; set; }

        public ClubMemberViewModel member { get; set; }
    }
}
