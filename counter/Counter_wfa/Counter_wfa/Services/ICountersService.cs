using Counter_wfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_wfa.Services
{
    public interface ICountersService
    {
        Task<bool> AddNewCounter(string counterName);
        Task<IEnumerable<Counter>> GetAllCounters();
    }
}
