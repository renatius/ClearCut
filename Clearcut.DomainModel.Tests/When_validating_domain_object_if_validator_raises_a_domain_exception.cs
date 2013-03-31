using System;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_validating_domain_object_if_validator_raises_a_domain_exception : AssertionHelper
    {
        class RaiseBusinessException : DomainObject
        {
            public AuthorizationException exception = new AuthorizationException("inner");

            protected override void RegisterConstraints()
            {
                Requires(() => { throw exception; }, null, "outer");
            }
        }

        [Test]
        public void business_exception_is_equal_to_original_exception()
        {
            var obj = new RaiseBusinessException();
            try
            {
                obj.Validate();
            }
            catch (DomainException exc)
            {
                Expect(exc, Is.EqualTo(obj.exception));
            }
        }
    }
}
