using System;
using Griffin.Decoupled.DomainEvents;
using Griffin.Logging;


namespace SportsRFIDTimer.Contracts.DomainEvents
{
    public class TagRegistered : DomainEventBase
    {
        private readonly ILogger _logger = LogManager.GetLogger<TagRegistered>();

        public TagRegistered(String rfidTag, DateTime time)
        {
            _logger.Info("Tag registered {0} {1}", rfidTag, time);
            RfIdTag = rfidTag;
            Time = time;
        }

        public String RfIdTag { get; private set; }
        public DateTime Time { get; private set; }
    }
}
