using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Griffin.Container;

namespace Repository
{
    [Component]
    public class UserMemoryRepository : IUserRepository
    {
        private List<User> _users;
 
        public UserMemoryRepository()
        {
            _users = new List<User>();
        }

        public User Get(Guid id)
        {
            return _users.FirstOrDefault(t => t.Id == id);
        }

        public void Save(User entity)
        {
            var existing = _users.SingleOrDefault(t => t.Id == entity.Id);
            if (existing != null)
            {
                _users.Insert(_users.IndexOf(existing), entity);
            }
            else
            {
                _users.Add(entity);
            }
        }

        public void Delete(User entity)
        {
            var existing = _users.SingleOrDefault(t => t.Id == entity.Id);
            if (existing != null)
            {
                _users.Remove(existing);
            }
        }

        public IEnumerable<User> FindAll()
        {
            return _users.ToArray();
        }

        public IEnumerable<User> Find(string text)
        {
            return _users.Where(t => t.Name.Contains(text));
        }
    }
}
