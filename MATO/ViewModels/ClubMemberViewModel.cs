using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class ClubMemberViewModel
    {
        public ClubViewModel Club { get; set; }

        public PersonViewModel Member { get; set; }
    }
}
