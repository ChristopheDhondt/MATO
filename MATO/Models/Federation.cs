using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class Federation
    {
        public string NameFr { get; set; }

        public string NameNl { get; set; }

        public string NameDe { get; set; }

        public Address OfficialAdress { get; set; }

        public Address PostalAdress { get; set; }

        public ICollection<Club> Clubs { get; set; }
    }
}
