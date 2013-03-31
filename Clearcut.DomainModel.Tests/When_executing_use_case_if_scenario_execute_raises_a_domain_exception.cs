using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_executing_use_case_if_scenario_execute_raises_a_domain_exception : AssertionHelper
    {
        [Test]
        public void the_domain_exception_raised_is_the_original_one()
        {
            var mocks = new MockRepository();
            var actor = mocks.StrictMock<Actor>();
            var scenario = mocks.StrictMock<Scenario>();
            var exception = new DomainException("error");

            Rhino.Mocks.Expect
                .Call(scenario.Authorize(actor))
                .Return(true);

            scenario.Execute();
            LastCall.Throw(exception);
            mocks.ReplayAll();

            try
            {
                UseCase.Execute(scenario, actor);
            }
            catch (DomainException exc)
            {
                Expect(exc, Is.EqualTo(exception));
            }
        }

    }
}
