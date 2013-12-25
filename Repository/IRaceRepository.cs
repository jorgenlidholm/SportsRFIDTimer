using System;
using System.Collections.Generic;
using Contracts;

namespace SportsRFIDTimer.Repository
{
    public interface IRaceRepository : IRepository<Race, Guid>
    {
        IEnumerable<Race> FindAll();
        IEnumerable<Race> Find(String text);
    }
}
