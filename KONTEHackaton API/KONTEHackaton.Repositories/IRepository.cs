using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTEHackaton.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();

    }
}
