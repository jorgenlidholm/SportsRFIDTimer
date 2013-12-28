using System;
using System.Collections.Generic;
using System.Linq;
using Griffin.Container;
using SportsRFIDTimer.Domain.Result;

namespace SportsRFIDTimer.Repository
{
    [Component]
    public class ResultMemoryRepository : IResultRepository
    {
        private readonly List<Result> _results; 

        public ResultMemoryRepository()
        {
            _results = new List<Result>();
        }

        public Result Get(Guid id)
        {
            return _results.FirstOrDefault(t => t.Id == id);
        }

        public void Save(Result entity)
        {
            var result = _results.FirstOrDefault(t => t.Id == entity.Id);
            if (result != null)
                _results.Remove(result);
            _results.Add(entity);
        }

        public void Delete(Result entity)
        {
            var result = _results.FirstOrDefault(t => t.Id == entity.Id);
            if (result != null)
                _results.Remove(result);
        }

        public IEnumerable<Result> FindAll()
        {
            return _results.ToArray();
        }

        public IEnumerable<Result> FindByRace(Guid raceId)
        {
            return _results.Where(t => t.RaceId == raceId);
        }

        public IEnumerable<Result> FindByUser(Guid userId)
        {
            return _results.Where(t => t.UserId == userId);
        }

        public Result FindByRaceAndUser(Guid raceId, Guid userId)
        {
            return _results.FirstOrDefault(t => t.RaceId == raceId && t.UserId == userId);
        }
    }
}