using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShow.Data.Models;

namespace TVShow.Core.Intefaces
{
    public interface IShowService
    {
        Task<IEnumerable<Show>> GetAllAsync();
        Task<Show?> GetByIdAsync(int id);
        Task AddAsync(Show show);
        Task UpdateAsync(Show show);
        Task DeleteAsync(int id);
    }
}
