using SportsRFIDTimer.Domain.User;
using Griffin.Decoupled.Commands;

namespace SportsRFIDTimer.Domain.Commands
{
    public class UpdateUser : CommandBase
    {
        private readonly User.User _user;

        public UpdateUser(User.User user)
        {
            _user = user;
        }

        public User.User User { get { return _user; } }
        
    }
}
