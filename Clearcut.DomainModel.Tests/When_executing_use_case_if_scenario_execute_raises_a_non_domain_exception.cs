using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_executing_use_case_if_scenario_execute_raises_a_non_domain_exception : AssertionHelper
    {
        MockRepository mocks;
        Actor actor;
        Scenario scenario;
        Exception exception;
       
        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            actor = mocks.StrictMock<Actor>();
            scenario = mocks.StrictMock<Scenario>();
            exception = new Exception("error");

            Rhino.Mocks.Expect
                .Call(scenario.Authorize(actor))
                .Return(true);

            scenario.Execute();
            LastCall.Throw(exception);
            mocks.ReplayAll();
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void a_domain_exception_is_raised()
        {
            UseCase.Execute(scenario, actor);
        }

        [Test]
        public void the_original_exception_is_chained_to_the_domain_exception()
        {
            try
            {
                UseCase.Execute(scenario, actor);
            }
            catch (DomainException exc)
            {
                Expect(exc.InnerException, Is.EqualTo(exception));
            }
        }

        [Test]
        public void the_domain_exception_message_is_equal_to_the_original_exception_message()
        {
            try
            {
                UseCase.Execute(scenario, actor);
            }
            catch (DomainException exc)
            {
                Expect(exc.Message, Is.EqualTo(exception.Message));
            }
        }

    }
}
