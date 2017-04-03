using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class MatoContextSeedData
    {
        private MatoContext _context;
        public MatoContextSeedData(MatoContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Federations.Any())
            {
                var persons = this.addPersons();

                var federations  = this.addFederations();

                var clubs = this.addClubs(federations);

                var clubMembers = this.addClubMembers(clubs, persons);

                var teams = this.addTeams(clubs);

                var teamCoachs = this.addTeamCoachs(teams, clubMembers);

                var teamMembers = this.addTeamMembers(teams, clubMembers);

                await _context.SaveChangesAsync();
            }
        }

        private List<Person> addPersons()
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    Firstname = "Laurent",
                    Lastname = "Demaret",
                    EmailAdress = "Laurent.Demaret@Gmail.com"
                },
                new Person()
                {
                    Firstname = "Quentin",
                    Lastname = "Dhondt",
                    EmailAdress = "Quentin.Dhondt@Gmail.com"
                }
            };
            _context.AddRange(persons);
            return persons;

        }

        private List<Federation> addFederations()
        {
            var federations = new List<Federation>()
            {     
                new Federation()
                {
                    Name = "F.F.T Federation francophone de Taekwondo",
                    PostalAdress = new Address()
                    {
                        Street = "Rue Beeckman",
                        PostNumber = "53",
                        PostCode = "1180",
                        City = "Uccle",
                        Country = "Belgique"
                    },
                    OfficialAdress = new Address()
                    {
                        Street = "Rue Beeckman",
                        PostNumber = "53",
                        PostCode = "1180",
                        City = "Uccle",
                        Country = "Belgique"
                    }
                }
            };
            _context.AddRange(federations);
            return federations;
        }

        private List<Club> addClubs(List<Federation> federations)
        {
            var clubs = new List<Club>()
            {
                new Club()
                {
                    Federation = federations[0],
                    Name = "KoreaClub",
                    PostalAdress = new Address()
                    {
                        Street = "Rue Beeckman",
                        PostNumber = "53",
                        PostCode = "1180",
                        City = "Uccle",
                        Country = "Belgique"
                    },
                    OfficialAdress = new Address()
                    {
                        Street = "Rue Beeckman",
                        PostNumber = "53",
                        PostCode = "1180",
                        City = "Uccle",
                        Country = "Belgique"
                    }
                },                
            };
            _context.AddRange(clubs);
            return clubs;
        }

        private List<ClubMember> addClubMembers(List<Club> clubs, List<Person> persons)
        {
            var clubmembers = new List<ClubMember>()
            {
                new ClubMember()
                {
                    Club = clubs[0],
                    Member = persons[0],
                },
                new ClubMember()
                {
                    Club = clubs[0],
                    Member = persons[1],
                },
            };
            _context.AddRange(clubmembers);
            return clubmembers;
        }

        private List<Team> addTeams(List<Club> clubs)
        {
            var teams = new List<Team>() {
                new Team()
                {
                    Club = clubs[0],
                    Name = " 5 / 7 ans"
                }
            };
            _context.AddRange(teams);
            return teams;
        }

        private List<TeamCoach> addTeamCoachs(List<Team> teams , List<ClubMember> clubMembers)
        {
            var teamCoachs = new List<TeamCoach>()
            {
                new TeamCoach()
                {
                    Team = teams[0],
                    Coach = clubMembers[0]
                }

            };
            _context.AddRange(teamCoachs);
            return teamCoachs;
        }     
       
        private List<TeamMember> addTeamMembers(List<Team> teams, List<ClubMember> clubMembers)
        {
            var teamMembers = new List<TeamMember>()
            {
                new TeamMember()
                {
                    Team = teams[0],
                    Member = clubMembers[1]
                }

            };
            _context.AddRange(teamMembers);
            return teamMembers;
        }        
    }
}
