using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_wfa.Models
{
    public class Counter
    {
        public string Name { get; }
        public Counter(string name)
        {
            Name = name;
        }
    }
}
