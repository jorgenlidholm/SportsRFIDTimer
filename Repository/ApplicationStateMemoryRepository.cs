using Contracts;
using Griffin.Container;

namespace SportsRFIDTimer.Repository
{
    [Component]
    public class ApplicationStateMemoryRepository : IApplicationStateRepository
    {
        private ApplicationState _applicationState;

        public ApplicationStateMemoryRepository()
        {
            _applicationState = new ApplicationState();
        }

        public ApplicationState Get(string id)
        {
            return _applicationState;
        }

        public ApplicationState Get()
        {
            return _applicationState;
        }

        public void Save(ApplicationState entity)
        {
            _applicationState = entity;
        }

        public void Delete(ApplicationState entity)
        {
            _applicationState = new ApplicationState();
        }
    }
}