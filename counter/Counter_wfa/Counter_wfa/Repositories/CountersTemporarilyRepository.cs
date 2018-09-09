using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter_wfa.Models;

namespace Counter_wfa.Repositories
{
    class CountersTemporarilyRepository : ICountersRepository
    {
        readonly List<Counter> counters;

        public CountersTemporarilyRepository()
        {
            counters = new List<Counter>();
        }

        public Task<IEnumerable<Counter>> GetCounters()
        {
            return Task.FromResult<IEnumerable<Counter>>(counters);
        }

        public Task SaveOrReplace(Counter counter)
        {
            var repoCounter = counters.FirstOrDefault(c => c.Name.Equals(counter.Name));
            if (repoCounter == null) return Task.Run(() => Save(counter));
            return Task.Run(() => Replace(repoCounter, counter));
        }

        void Save(Counter counter)
        {
            counters.Add(counter);
        }

        void Replace(Counter old, Counter newCounter)
        {
            var index = counters.IndexOf(old);
            counters.RemoveAt(index);
            counters.Insert(index, newCounter);
        }
    }
}
