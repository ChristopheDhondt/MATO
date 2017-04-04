using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MATO.Models
{
    public class MatoContext : DbContext
    {
        private IConfigurationRoot _appSettings;

        public MatoContext(IConfigurationRoot appSettings, DbContextOptions<MatoContext> options) : base(options)
        {
            _appSettings = appSettings;
        }

        public DbSet<Federation> Federations { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Club> Clubs { get; set; }
        
        public DbSet<Person> Persons { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_appSettings["ConnectionStrings:MatoContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClubMember>().HasKey(x => new { x.ClubId, x.MemberId });
            modelBuilder.Entity<TeamCoach>().HasKey(x => new { x.TeamId, x.CoachId });
            modelBuilder.Entity<TeamMember>().HasKey(x => new { x.TeamId, x.MemberId });
        }
    }
}
