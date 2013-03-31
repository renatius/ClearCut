using System;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_validating_domain_object_property_if_validator_raises_a_domain_exception : AssertionHelper
    {
        class RaiseBusinessException : DomainObject
        {
            public string A { get; set; }
            public AuthorizationException exception = new AuthorizationException("inner");

            protected override void RegisterConstraints()
            {
                Requires(() => { throw exception; }, "A", "outer");
            }
        }

        [Test]
        public void business_exception_is_equal_to_original_exception()
        {
            var obj = new RaiseBusinessException();
            try
            {
                obj.Validate("A");
            }
            catch (DomainException exc)
            {
                Expect(exc, Is.EqualTo(obj.exception));
            }
        }

    }
}
