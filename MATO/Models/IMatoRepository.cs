using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATO.ViewModels;

namespace MATO.Models
{
    public interface IMatoRepository
    {
        IEnumerable<Federation> GetAllFederations();

        Federation FindFederation(int? id);

        Task<bool> AddFederation(Federation federation);

        Task<bool> SaveChangesAsync();

        Task<bool> DeleteFederation(int? id);
    }
}
