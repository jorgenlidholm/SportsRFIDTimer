using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Griffin.Container;

namespace SportsRFIDTimer.Repository
{
    [Component]
    public class RaceMemoryRepository : IRaceRepository
    {
        private List<Race> _races;

        public RaceMemoryRepository()
        {
            _races=new List<Race>();
        }

        public Race Get(Guid id)
        {
            return _races.First(t => t.Id == id);
        }

        public void Save(Race entity)
        {
            var existing = _races.FirstOrDefault(t => t.Id == entity.Id);
            if (existing != null)
            {
                _races.Remove(existing);
            }
            _races.Add(entity);
        }

        public void Delete(Race entity)
        {
            var existing = _races.FirstOrDefault(t => t.Id == entity.Id);
            if (existing != null)
                _races.Remove(existing);
        }

        public IEnumerable<Race> FindAll()
        {
            return _races.ToArray();
        }

        public IEnumerable<Race> Find(String text)
        {
            return _races.Where(t => t.Name.ToLower().Contains(text.ToLower())).ToArray();
        }
    }
}