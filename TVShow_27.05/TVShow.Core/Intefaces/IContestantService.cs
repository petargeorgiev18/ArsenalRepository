using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShow.Data.Models;

namespace TVShow.Core.Intefaces
{
    public interface IContestantService
    {
        Task<IEnumerable<Contestant>> GetAllAsync();
        Task<Contestant?> GetByIdAsync(int id);
        Task AddAsync(Contestant contestant);
        Task UpdateAsync(Contestant contestant);
        Task DeleteAsync(int id);
    }
}
