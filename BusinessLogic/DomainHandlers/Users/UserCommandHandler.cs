using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Griffin.Decoupled.Commands;
using SportsRFIDTimer.Domain;
using SportsRFIDTimer.Domain.Commands;
using SportsRFIDTimer.Domain.User;

namespace SportsRFIDTimer.BusinessLogic.DomainHandlers.Users
{
    public class UserCommandHandler : IHandleCommand<UpdateUser>
    {
        public void Invoke(UpdateUser command)
        {
            // Find repository for user.
            using (var container = DomainManager.Container.CreateChildContainer())
            {
                var repo = container.Resolve<IUserRepository>();
                repo.Save(command.User);
            }
        }
    }
}
