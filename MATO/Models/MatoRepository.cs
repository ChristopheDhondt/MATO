using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class MatoRepository:IMatoRepository
    {
        public MatoContext _context;

        public MatoRepository(MatoContext context)
        {
            _context = context;
        }

        public void AddFederation(Federation newFederation)
        {
            _context.Add(newFederation);
        }

        public Federation FindFederation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Federation> GetAllFederations()
        {
            return _context.Federations.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
