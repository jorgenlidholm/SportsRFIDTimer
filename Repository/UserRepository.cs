using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Griffin.Container;
using SportsRFIDTimer.Domain.User;
using SportsRFIDTimer.Repository.Dto;
using SportsRFIDTimer.Repository.Utilities;

namespace SportsRFIDTimer.Repository
{
    [Component]
    public class UserRepository : IUserRepository
    {
        public User Get(Guid id)
        {
            User user;
            using (var ctx = new SportsRfidTimerContext())
            {
                user = ctx.Users.Find(id);
            }
            return user;
        }

        public void Save(User entity)
        {
            using (var ctx = new SportsRfidTimerContext())
            {
                var user = ctx.Users.Find(entity.Id);
                if (user != null)
                {
                    user.Update(entity);
                    ctx.Users.Attach(user);
                }
                else
                {
                    ctx.Users.Add(entity);
                }
                if (ctx.ChangeTracker.HasChanges())
                    Console.WriteLine("User Changed.");
                
                ctx.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (var ctx = new SportsRfidTimerContext())
            {
                ctx.Users.Remove(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<User> FindAll()
        {
            var query = String.Format("SELECT * FROM Users");
            using (var ctx  = new SportsRfidTimerContext())
            {
                return ctx.Users.ToArray();
            }
        }

        public IEnumerable<User> Find(string text)
        {
            var query = String.Format("Select * from Users Where Name LIKE '%{0}%' OR Meta LIKE '%{0}%'", text);
            using (var ctx = new SportsRfidTimerContext())
            {
                var users = ctx.Users.SqlQuery(query);
                bool any = users.AnyAsync().Wait(TimeSpan.FromSeconds(1));
                if (any)
                {
                    return users.ToArray();
                }
            }
            return Enumerable.Empty<User>();
        }


        public async Task<IEnumerable<User>> FindAsync(string text)
        {
            IEnumerable<User> result = Enumerable.Empty<User>();
            var query = String.Format("Select * from Users Where {0} in Name OR {0} in Meta", text.Fnuttify());
            using (var ctx = new SportsRfidTimerContext())
            {
                var users = ctx.Users.SqlQuery(query);
                bool any = await users.AnyAsync();
                if (any)
                    result = await users.ToArrayAsync();
            }
            return result;
        }

        public User FindByTag(string idString)
        {
            User result;
            var query = String.Format("Select * from Users Where TagId = {0}", idString.Fnuttify());
            using (var ctx = new SportsRfidTimerContext())
            {
                var users = ctx.Users.SqlQuery(query);
                result = users.FirstOrDefault();
            }
            return result;
        }
    }
}
