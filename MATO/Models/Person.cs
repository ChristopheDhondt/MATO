using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public Address OfficialAdress { get; set; }

        public Address PostalAdress { get; set; }

        public string EmailAdress { get; set; }

        public string LastConnection { get; set; }

        public ICollection<ClubMember> ClubMembers { get; set; }
    }
}