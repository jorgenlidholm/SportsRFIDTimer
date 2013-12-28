using System;
using Griffin.Logging;

namespace SportsRFIDTimer.Domain.Events
{
    public class UserCreated
    {
        private readonly ILogger _logger = LogManager.GetLogger<UserCreated>();

        public UserCreated(String name)
        {
            
        }
    }
}
