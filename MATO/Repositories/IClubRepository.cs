using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATO.Models
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAllClubs();

        Task<Club> FindClub(int? id);

        Task<bool> AddClub(Club club);

        Task<bool> SaveChangesAsync();

        Task<bool> DeleteClub(int? id);
    }
}
