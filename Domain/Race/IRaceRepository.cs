using System;
using System.Collections.Generic;

namespace SportsRFIDTimer.Domain.Race
{
    public interface IRaceRepository : IRepository<global::SportsRFIDTimer.Domain.Race.Race, Guid>
    {
        IEnumerable<global::SportsRFIDTimer.Domain.Race.Race> FindAll();
        IEnumerable<global::SportsRFIDTimer.Domain.Race.Race> Find(String text);
    }
}
