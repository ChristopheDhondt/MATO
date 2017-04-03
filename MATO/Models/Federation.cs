using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class Federation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "error.message.length")]
        public string Name { get; set; }       

        public Address OfficialAdress { get; set; }

        public Address PostalAdress { get; set; }

        public ICollection<Club> Clubs { get; set; }
    }
}
