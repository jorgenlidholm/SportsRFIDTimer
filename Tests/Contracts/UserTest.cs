using System;
using Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Contracts
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CreateUserShouldThrowOnMissingParamaters()
        {
            var act = new Action(() => { var user = new User(null, 0); });
            act.ShouldThrow<ArgumentNullException>();

            act = new Action(() => { var user = new User("", 0); });
            act.ShouldThrow<ArgumentException>();

            act = new Action(() => { var user = new User("Jörgen Lidholm", -1); });
            act.ShouldThrow<ArgumentException>();
        }
    }
}
