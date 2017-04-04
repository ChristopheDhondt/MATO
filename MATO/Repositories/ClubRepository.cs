using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MATO.Models
{
    public class ClubRepository: IClubRepository
    {
        public MatoContext _context;

        public ClubRepository(MatoContext context)
        {
            _context = context;            
        }

        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> FindClub(int? id)
        {
            return await _context.Clubs.Include(c => c.OfficialAdress)
                                       .Include(c => c.PostalAdress)
                                       .Include(c => c.ClubMembers)
                                       .Include(c => c.Teams)                                       
                                       .SingleAsync(c => c.Id == id);
        }

        public Task<bool> AddClub(Club newClub)
        {
            _context.Add(newClub);
            return this.SaveChangesAsync();
        }

        public Task<bool> DeleteClub(int? id)
        {
            var federation = this.FindClub(id);
            _context.Remove(federation.Result.PostalAdress);
            _context.Remove(federation.Result.OfficialAdress);
            foreach (var clubMember in federation.Result.ClubMembers) _context.Remove(clubMember);
            foreach (var team in federation.Result.Teams) _context.Remove(team);                 
            _context.Remove(federation.Result);
            return this.SaveChangesAsync();
        }

        private void DeleteSubEntities()
        {
            //foreach (var clubMember in subEntities)
            //{
            //    _context.Remove(clubMember);
            //}
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
