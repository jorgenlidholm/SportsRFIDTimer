using System;
using System.Collections.Generic;
using SportsRFIDTimer.Domain.User;

namespace SportsRFIDTimer.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(string text)
        {
            throw new NotImplementedException();
        }

        public User FindByTag(string idString)
        {
            throw new NotImplementedException();
        }
    }
}
