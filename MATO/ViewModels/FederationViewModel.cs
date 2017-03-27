using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class FederationViewModel
    {
        public string NameFr { get; set; }

        public string NameNl { get; set; }

        public string NameDe { get; set; }

        public AddressViewModel OfficialAdress { get; set; }

        public AddressViewModel PostalAdress { get; set; }

        public ICollection<ClubViewModel> Clubs { get; set; }
    }
}
