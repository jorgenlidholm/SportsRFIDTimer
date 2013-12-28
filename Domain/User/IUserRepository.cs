using System;
using System.Collections.Generic;

namespace SportsRFIDTimer.Domain.User
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        IEnumerable<User> FindAll();
        IEnumerable<User> Find(String text);
        User FindByTag(string idString);
    }
}
