using System;
using System.Collections.Generic;
using Contracts;
using SportsRFIDTimer.Contracts;

namespace SportsRFIDTimer.Repository
{
    public interface IResultRepository : IRepository<Result, Guid>
    {
        IEnumerable<Result> FindAll();
        IEnumerable<Result> FindByRace(Guid raceId);
        IEnumerable<Result> FindByUser(Guid userId);
        Result FindByRaceAndUser(Guid raceId, Guid userId);
    }
} 