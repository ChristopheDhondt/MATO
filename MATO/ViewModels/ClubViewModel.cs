using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class ClubViewModel
    {
        public string Name { get; set; }

        public AddressViewModel OfficialAdress { get; set; }

        public AddressViewModel PostalAdress { get; set; }

        public FederationViewModel Federation { get; set; }

        public ICollection<TeamViewModel> Teams { get; set; }

        public ICollection<ClubMemberViewModel> ClubMembers { get; set; }
        
    }
}
