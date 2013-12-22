using System;
using System.Collections.Generic;
using Contracts;

namespace Repository
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        IEnumerable<User> FindAll();
        IEnumerable<User> Find(String text);
    }
}
