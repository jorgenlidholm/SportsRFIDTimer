using System;
using Griffin.Decoupled.DomainEvents;

namespace SportsRFIDTimer.Contracts.DomainEvents
{
    public class MessageLogged : DomainEventBase
    {
        public MessageLogged(DateTime dateTime, string typeName, string logLevel, string message)
        {
            DateTime = dateTime;
            TypeName = typeName;
            LogLevel = logLevel;
            Message = message;
        }

        public DateTime DateTime { get; private set; }
        public string TypeName { get; private set; }
        public string LogLevel { get; private set; }
        public string Message { get; private set; }
    }
}