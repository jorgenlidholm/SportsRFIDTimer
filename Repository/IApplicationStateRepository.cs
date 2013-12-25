using System;
using Contracts;

namespace SportsRFIDTimer.Repository
{
    public interface IApplicationStateRepository : IRepository<ApplicationState,String>
    {
        ApplicationState Get();
    }
}
