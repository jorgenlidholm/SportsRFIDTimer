using System;
using Griffin.Logging;

namespace SportsRFIDTimer
{
    public class DomainLogManager : ILogManager
    {
        public ILogger GetLogger(Type type)
        {
            return DomainLogger.Instance(type);
        }
    }
}