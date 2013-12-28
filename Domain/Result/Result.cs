using System;
using System.Collections.Generic;

namespace SportsRFIDTimer.Domain.Result
{
    public class Result
    {
        private readonly List<DateTime> _registrations;

        public Result(Guid raceId, Guid userId)
        {
            if(raceId == Guid.Empty)
                throw new ArgumentException("Guid.Empty is not a valid argument", "raceId");
            if (userId == Guid.Empty)
                throw new ArgumentException("Guid.Empty is not a valid argument", "userId");
            Id = Guid.NewGuid();
            RaceId = raceId;
            UserId = userId;
            _registrations = new List<DateTime>();
        }

        public Guid Id { get; set; }
        public Guid RaceId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime PlannedStartTime { get; set; }

        public IList<DateTime> Registrations { get { return _registrations; } }

        public void AddRegistrations(DateTime time)
        {
            _registrations.Add(time);
        }
    }
}
