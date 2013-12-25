using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Race
    {

        public Race(String name, RaceType raceType)
        {
            Name = name;
            RaceType = raceType;
        }

        public Guid Id { get; private set; }
        public RaceType RaceType { get; private set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public String Meta { get; set; }
    }
}
