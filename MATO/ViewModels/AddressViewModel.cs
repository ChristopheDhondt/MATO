using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.ViewModels
{
    public class AddressViewModel
    {
        [StringLength(250, MinimumLength =5)]
        public string Street { get; set; }

        public string PostNumber { get; set; }

        public string PostBox { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
