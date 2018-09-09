using Counter_wfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_wfa.Repositories
{
    public interface ICountersRepository
    {
        Task SaveOrReplace(Counter counter);
        Task<IEnumerable<Counter>> GetCounters();
    }
}
