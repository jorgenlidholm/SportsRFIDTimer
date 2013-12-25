using System;
using Griffin.Container;
using Griffin.Decoupled.DomainEvents;
using Griffin.Logging;
using SportsRFIDTimer.Contracts;
using SportsRFIDTimer.Contracts.DomainEvents;
using SportsRFIDTimer.Domain;
using SportsRFIDTimer.Repository;

namespace SportsRFIDTimer.BusinessLogic.DomainHandlers.Users
{
    [Component]
    public class RfidTagRegistrationHandler : ISubscribeOn<TagRegistered>
    {
        private readonly ILogger _logger = LogManager.GetLogger<RfidTagRegistrationHandler>();
        public void Handle(TagRegistered domainEvent)
        {
           _logger.Info("Received TagRegistered command.");
            var container = DomainManager.Container.CreateChildContainer();

            var repo = container.Resolve<IApplicationStateRepository>();
            var currentRaceId = repo.Get().CurrentRace;
            if (currentRaceId.HasValue)
            {
                _logger.Info("Register tag-event on user result");
                RegisterUserEvent(currentRaceId.Value, domainEvent);
            }
            else
            {
                _logger.Info("No race running, probably we want to register tag with user.");
                var userId = repo.Get().CurrentUser;
                if (userId.HasValue)
                {
                    RegisterTagWithUser(userId.Value, domainEvent);
                }
                else
                {
                    _logger.Warning("TagRegistered event not handled, either race or user not selected.");
                }
            }
        }

        private void RegisterTagWithUser(Guid value, TagRegistered domainEvent)
        {
            var userRepository = DomainManager.Container.Resolve<IUserRepository>();
            var user = userRepository.Get(value);
            user.TagId = domainEvent.RfIdTag;
        }

        private void RegisterUserEvent(Guid raceId, TagRegistered domainEvent)
        {
            _logger.Info("Finding user with TagId: {0}", domainEvent.RfIdTag);
            //var raceRepository = DomainManager.Container.Resolve<IRaceRepository>();
            var userRepository = DomainManager.Container.Resolve<IUserRepository>();
            var resultRepository = DomainManager.Container.Resolve<IResultRepository>();
            //var race = raceRepository.Get(raceId);
            var user = userRepository.FindByTag(domainEvent.RfIdTag);
            var result = resultRepository.FindByRaceAndUser(raceId, user.Id);

            UpdateResult(result ?? new Result(raceId, user.Id), domainEvent);
        }

        private void UpdateResult(Result result, TagRegistered command)
        {
            result.AddRegistrations(command.Time);
        }

    }
}
