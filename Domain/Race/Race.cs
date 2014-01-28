using System;
using System.ComponentModel.DataAnnotations;

namespace SportsRFIDTimer.Domain.Race
{
    public class Race
    {

        public Race(String name, RaceType raceType)
        {
            Name = name;
            RaceType = raceType;
        }

        [Key]
        public Guid Id { get; private set; }
        public RaceType RaceType { get; private set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public String Meta { get; set; }
    }
}
