using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter_wfa.Models;
using Counter_wfa.Repositories;

namespace Counter_wfa.Services
{
    public class CountersService : ICountersService
    {
        readonly ICountersRepository repository;

        public CountersService(ICountersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddNewCounter(string counterName)
        {
            if ((await GetAllCounters()).Any(c => c.Name.Equals(counterName)))
                return false;
            var counter = new Counter(counterName);
            await repository.SaveOrReplace(counter);
            return true;
        }

        public Task<IEnumerable<Counter>> GetAllCounters()
        {
            return repository.GetCounters();
        }

        public async Task IncrementCount(Counter counter)
        {
            counter.Count++;
            await repository.SaveOrReplace(counter);
        }
    }
}
