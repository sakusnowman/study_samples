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
        public CountersChangedMessage(IEnumerable<Counter> counters) { }
    }
}
