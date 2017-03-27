using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class ClubMember
    {
        public Club Club { get; set; }

        public Person Member { get; set; }
    }
}
