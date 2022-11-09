using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskFour
{
    public readonly struct Movie
    {
        public string Name { get; }
        public int Duration { get; }
        public bool HasOscars { get; }

        public Movie(string name, int duration, bool hasOscars)
        {
            Name = name;
            Duration = duration;
            HasOscars = hasOscars;
        }

        public bool HasEqualKeyTo(string name) => Name == name;
    }
}
