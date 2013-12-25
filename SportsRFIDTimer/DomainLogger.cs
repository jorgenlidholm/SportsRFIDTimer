using System;
using System.Collections.Generic;
using Griffin.Decoupled.DomainEvents;
using Griffin.Logging;

namespace SportsRFIDTimer
{
    public class DomainLogger : ILogger
    {
        private static Dictionary<Type,ILogger> _loggers = new Dictionary<Type, ILogger>();
        private string _typeName;

        public static ILogger Instance(Type type)
        {
            if (_loggers.ContainsKey(type))
                return _loggers[type];
            var typeLogger = new DomainLogger(type);
            _loggers.Add(type, typeLogger);
            return typeLogger;
        }

        private DomainLogger(Type type)
        {
            _typeName = type.Name;
        }

        public void Debug(string message)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "DEBUG", message));
        }

        public void Debug(string message, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now,_typeName,"DEBUG", String.Format(message, formatters)));
        }

        public void Debug(string message, Exception exception)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "DEBUG", String.Format("{0}:{1}", message, exception.Message)));
        }

        public void Debug(string message, Exception exception, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "DEBUG", String.Format(message, formatters)));
        }

        public void Error(string message)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "ERROR", message));
        }

        public void Error(string message, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "ERROR", String.Format(message, formatters)));
        }

        public void Error(string message, Exception exception)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "ERROR", String.Format("{0}:{1}", message, exception.Message)));
        }

        public void Error(string message, Exception exception, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "ERROR", String.Format(message, formatters)));
        }

        public void Info(string message)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "INFO", message));
        }

        public void Info(string message, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "INFO", String.Format(message, formatters)));
        }

        public void Info(string message, Exception exception)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "INFO", String.Format("{0}:{1}", message, exception.Message)));
        }

        public void Info(string message, Exception exception, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "INFO", String.Format(message, formatters)));
        }

        public void Warning(string message)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "WARNING", message));
        }

        public void Warning(string message, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "WARNING", String.Format(message, formatters)));
        }

        public void Warning(string message, Exception exception)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "WARNING", String.Format("{0}:{1}", message, exception.Message)));
        }

        public void Warning(string message, Exception exception, params object[] formatters)
        {
            DomainEvent.Publish(new MessageLogged(DateTime.Now, _typeName, "WARNING", String.Format(message, formatters)));
        }
    }
}