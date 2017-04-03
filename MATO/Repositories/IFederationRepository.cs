using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public interface IFederationRepository
    {
        Task<IEnumerable<Federation>> GetAllFederations();

        Task<Federation> FindFederation(int? id);

        Task<bool> AddFederation(Federation federation);

        Task<bool> SaveChangesAsync();

        Task<bool> DeleteFederation(int? id);
    }
}
