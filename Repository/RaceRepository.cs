using System;
using System.Collections.Generic;
using SportsRFIDTimer.Domain.Race;
using SportsRFIDTimer.Repository.Dto;

namespace SportsRFIDTimer.Repository
{
    public class RaceRepository : IRaceRepository
    {
        public Race Get(Guid id)
        {
            Race race;
            using (var ctx = new SportsRfidTimerContext())
            {
                race = ctx.Races.Find(id);
            }
            return race;
        }

        public void Save(Race entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Race entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Race> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Race> Find(String text)
        {
            throw new NotImplementedException();
        }
    }
}