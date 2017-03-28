using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public class MatoRepository:IMatoRepository
    {
        public MatoContext __context;

        public MatoRepository(MatoContext context)
        {
            __context = context;
        }

        public void AddFederation(Federation newFederation)
        {
            __context.Add(newFederation);
        }

        public Federation FindFederation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Federation> GetAllFederations()
        {
            return __context.Federations.ToList();
        }
    }
}
