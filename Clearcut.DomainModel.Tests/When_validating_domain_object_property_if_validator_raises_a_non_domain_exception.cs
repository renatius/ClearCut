using System;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_validating_domain_object_property_if_validator_raises_a_non_domain_exception : AssertionHelper
    {
        class NonDomainException : DomainObject
        {
            public string A { get; set; }

            public Exception exception = new Exception("inner");

            protected override void RegisterConstraints()
            {
                Requires(() => { throw exception; }, "A", "outer");
            }
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void a_domain_exception_is_raised()
        {
            var obj = new NonDomainException();
            obj.Validate("A");
        }

        [Test]
        public void original_exception_is_chained_to_domain_exception()
        {
            var obj = new NonDomainException();
            try
            {
                obj.Validate("A");
            }
            catch (DomainException exc)
            {
                Expect(exc.InnerException, Is.EqualTo(obj.exception));
            }
        }

        [Test]
        public void business_exception_message_is_equal_to_original_exception_message()
        {
            var obj = new NonDomainException();
            try
            {
                obj.Validate("A");
            }
            catch (DomainException exc)
            {
                Expect(exc.Message, Is.EqualTo(obj.exception.Message));
            }
        }

    }
}
