using System;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_precondition_is_evaluated : AssertionHelper
    {
        [Test]
        [ExpectedException(typeof(DomainException))]
        public void error_message_cannot_be_null()
        {
            Precondition.Requires(true, null);
        }

        [Test]
        public void if_condition_is_true_no_exception_is_raised()
        {
            Precondition.Requires(true, "no exception");
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void if_condition_is_false_a_domain_exception_is_raised()
        {
            Precondition.Requires(false, "precondition violation");
        }

        [Test]
        public void if_condition_is_false_the_exception_message_must_correspond_to_the_precondition_error_message()
        {
            const string errorMessage = "bla bla bla";
            try
            {
                Precondition.Requires(false, errorMessage);
            }
            catch (DomainException exc)
            {
                Expect(exc.Message, Is.EqualTo(errorMessage));
            }
        }
    }
}
