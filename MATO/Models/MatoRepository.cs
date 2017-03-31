using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATO.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MATO.Models
{
    public class MatoRepository: IMatoRepository
    {
        public MatoContext _context;

        public MatoRepository(MatoContext context)
        {
            _context = context;            
        }

        public Federation FindFederation(int? id)
        {
            return _context.Federations.Include(f => f.OfficialAdress).Include(f => f.PostalAdress).Single(f => f.Id == id);            
        }

        public IEnumerable<Federation> GetAllFederations()
        {
            return _context.Federations.ToList();
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
            _context.Remove(federation.PostalAdress);

            _context.Remove(federation.OfficialAdress);

            _context.Remove(federation);

            return this.SaveChangesAsync();
        }
    }
}
