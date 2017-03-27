using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address OfficialAdress { get; set; }

        public Address  PostalAdress { get; set; }

        public Federation Federation { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<ClubMember> ClubMembers { get; set; }
    }
}
