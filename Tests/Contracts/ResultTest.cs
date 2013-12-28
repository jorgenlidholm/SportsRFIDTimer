using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsRFIDTimer.Domain.Result;

namespace SportsRFIDTimer.Tests.Contracts
{
    [TestClass]
    public class ResultTest
    {
        [TestMethod,TestCategory("unit")]
        public void CreatingAResultShouldNotThrowWithValidGuids()
        {
            var action = new Action(() => { var result = new Result(Guid.NewGuid(), Guid.NewGuid()); });
            action.ShouldNotThrow();
        }

        [TestMethod,TestCategory("unit")]
        public void CreatingAResultWithGuidEmptyShouldThrow()
        {
            var action = new Action(() => { var result = new Result(Guid.Empty, Guid.NewGuid()); });
            action.ShouldThrow<ArgumentException>();
            
            action = new Action(() => { var result = new Result(Guid.NewGuid(), Guid.Empty); });
            action.ShouldThrow<ArgumentException>();

            action = new Action(() => { var result = new Result(Guid.Empty, Guid.Empty); });
            action.ShouldThrow<ArgumentException>();
        }
    }
}
