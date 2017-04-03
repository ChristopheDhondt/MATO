using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MATO.Models
{
    public class FederationRepository: IFederationRepository
    {
        public MatoContext _context;

        public FederationRepository(MatoContext context)
        {
            _context = context;            
        }

        public async Task<Federation> FindFederation(int? id)
        {
            return await _context.Federations.Include(f => f.OfficialAdress).Include(f => f.PostalAdress).SingleAsync(f => f.Id == id);            
        }

        public async Task<IEnumerable<Federation>> GetAllFederations()
        {
            return await _context.Federations.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public Task<bool> AddFederation(Federation newFederation)
        {             
            _context.Add(newFederation);
            return this.SaveChangesAsync();
        }

        public Task<bool> DeleteFederation(int? id)
        {
            var federation = this.FindFederation(id);
            _context.Remove(federation.Result.PostalAdress);
            _context.Remove(federation.Result.OfficialAdress);
            _context.Remove(federation.Result);
            return this.SaveChangesAsync();
        }
    }
}
