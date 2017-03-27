using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class PersonViewModel
    {
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public AddressViewModel OfficialAdress { get; set; }

        public AddressViewModel PostalAdress { get; set; }

        public string EmailAdress { get; set; }

        public string LastConnection { get; set; }
    }
}
