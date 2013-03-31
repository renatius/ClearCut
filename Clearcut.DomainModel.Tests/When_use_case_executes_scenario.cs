using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_use_case_executes_scenario : AssertionHelper
    {
        [Test]
        [ExpectedException(typeof(DomainException))]
        public void scenario_cannot_be_null()
        {
            var mocks = new MockRepository();
            var actor = mocks.StrictMock<Actor>();
            UseCase.Execute(null, actor);
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void actor_cannot_be_null()
        {
            var mocks = new MockRepository();
            var scenario = mocks.StrictMock<Scenario>();
            UseCase.Execute(scenario, null);
        }

        [Test]
        public void execute_is_called_after_authorize()
        {
            var mocks = new MockRepository();
            var actor = mocks.StrictMock<Actor>();
            var scenario = mocks.StrictMock<Scenario>();

            using (mocks.Ordered())
            {
                Rhino.Mocks.Expect
                    .Call(scenario.Authorize(actor))
                    .Return(true);

                scenario.Execute();
            }
            mocks.ReplayAll();

            UseCase.Execute(scenario, actor);

            mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(AuthorizationException))]
        public void if_authorize_returns_false_an_authorization_exception_is_raised()
        {
            var mocks = new MockRepository();
            var actor = mocks.StrictMock<Actor>();
            var scenario = mocks.StrictMock<Scenario>();

            Rhino.Mocks.Expect
                .Call(scenario.Authorize(actor))
                .Return(false);

            scenario.Execute();

            mocks.ReplayAll();

            UseCase.Execute(scenario, actor);
        }
    }
}
