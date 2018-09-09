using Counter_wfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_wfa.Messages
{
    public class CountersChangedMessage
    {
        readonly IEnumerable<Counter> counters;
        public CountersChangedMessage(IEnumerable<Counter> counters)
        {
            this.counters = counters;
        }

        public IEnumerable<string> CountersToString()
        {
            return counters.Select(c => c.Count + "\t" + c.Name);
        }
    }
}
