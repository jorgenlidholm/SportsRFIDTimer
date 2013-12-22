using System;
using System.Reflection;
using Contracts;
using FluentAssertions;
using Griffin.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace Tests.Repository
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestInitialize]
        public void Init()
        {
            var repository = new ContainerRegistrar();
            repository.RegisterComponents(Lifetime.Default, Assembly.GetAssembly(typeof(UserMemoryRepository)));
            repository.Build();
        }

        [TestMethod]
        public void SaveUserShouldInsertUserIntoRepository()
        {
            var registrar = new ContainerRegistrar();
            var container = registrar.Build();
            var user = new User("Jöregen Lidholm", 11);

            var repo = container.Resolve<IUserRepository>();
            repo.Save(user);
            var result = repo.Get(user.Id);
            result.Id.Should().Be(user.Id);
        }
    }
}
