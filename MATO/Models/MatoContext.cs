using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MATO.Models
{
    public class MatoContext : DbContext
    {
        public MatoContext()
        {

        }

        public DbSet<Federation> Federations { get; set; }

        public DbSet<Club> Clubs { get; set; }
        
        public DbSet<Person> Persons { get; set; }

        public DbSet<Team> Teams { get; set; }    

    }
}
