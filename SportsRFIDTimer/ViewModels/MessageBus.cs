using Microsoft.Practices.Prism.Events;

namespace SportsRFIDTimer.ViewModels
{
    public class MessageBus : IEventAggregator
    {
        private static MessageBus _messageBus;
        private readonly IEventAggregator _eventAggregator;

        public static IEventAggregator Instance()
        {
            return _messageBus ?? (_messageBus = new MessageBus());
        }

        private MessageBus()
        {
            _eventAggregator = new EventAggregator();
        }

        public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
        {
            return _eventAggregator.GetEvent<TEventType>();
        }
    }
}