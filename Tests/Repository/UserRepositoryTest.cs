using System.Linq;
using Contracts;
using FluentAssertions;
using Griffin.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsRFIDTimer.Repository;

namespace SportsRFIDTimer.Tests.Repository
{
    [TestClass]
    public class UserRepositoryTest
    {
        private ContainerRegistrar _registrar;

        [TestInitialize]
        public void Init()
        {
            _registrar = new ContainerRegistrar();
            _registrar.RegisterConcrete<UserMemoryRepository>(Lifetime.Singleton);
            _registrar.Build();
        }

        [TestMethod, TestCategory("repository")]
        public void SaveUserShouldInsertUserIntoRepository()
        {
            var container = _registrar.Build();
            var user = new User("Jöregen Lidholm", 11);

            var repo = container.Resolve<IUserRepository>();
            repo.Save(user);
            var result = repo.Get(user.Id);
            result.Id.Should().Be(user.Id);
        }

        [TestMethod, TestCategory("repository")]
        public void UpdatingUserShouldNotInsertNewUserIntoRepository()
        {
            var container = _registrar.Build();
            var user = new User("Jöregen Lidholm", 11);

            var repo = container.Resolve<IUserRepository>();
            repo.Save(user);
            var result = repo.Get(user.Id);
            result.Id.Should().Be(user.Id);
            
            user.Meta = "GasGas EC 300";
            repo.Save(user);
            var users = repo.FindAll().ToArray();
            users.Count().Should().Be(1);
            users.Count(t=>t.Meta == "GasGas EC 300").Should().Be(1);
        }
    }
}
