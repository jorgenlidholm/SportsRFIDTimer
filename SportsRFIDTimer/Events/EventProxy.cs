
using Griffin.Container;
using Griffin.Decoupled.DomainEvents;
using Griffin.Logging;
using Microsoft.Practices.Prism.Events;
using SportsRFIDTimer.ViewModels;

namespace SportsRFIDTimer.Events
{
    [Component]
    public class EventProxy : ISubscribeOn<MessageLogged>
    {
        private readonly IEventAggregator _eventAggregator ;
        private readonly ILogger _logger = LogManager.GetLogger<EventProxy>();
        public EventProxy()
        {
            //_logger.Debug("EventProxy created.");
            _eventAggregator = MessageBus.Instance();

        }

        public void Handle(MessageLogged domainEvent)
        {
            //_logger.Info("Relaying MessageLogged event.");
            _eventAggregator.GetEvent<MessageLoggedEvent>().Publish(domainEvent);
        }
    }
}
