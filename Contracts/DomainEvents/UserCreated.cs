using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Griffin.Logging;

namespace SportsRFIDTimer.Contracts.DomainEvents
{
    public class UserCreated
    {
        private readonly ILogger _logger = LogManager.GetLogger<UserCreated>();

        public UserCreated(String name)
        {
            
        }
    }
}
