using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public interface IMatoRepository
    {
        IEnumerable<Federation> GetAllFederations();

        Federation FindFederation(int id);

        void AddFederation(Federation federation);

        Task<bool> SaveChangesAsync();
    }
}
