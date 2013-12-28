using System;

namespace SportsRFIDTimer.Domain.Application
{
    public interface IApplicationStateRepository : IRepository<ApplicationState,String>
    {
        ApplicationState Get();
    }
}
