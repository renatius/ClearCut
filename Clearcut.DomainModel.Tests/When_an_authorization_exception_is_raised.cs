using System;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_an_authorization_exception_is_raised : AssertionHelper
    {
        [Test]
        public void it_can_be_caught_as_a_security_exception()
        {
            var exception = new AuthorizationException();
            try
            {
                throw exception;
            }
            catch (SecurityException exc)
            {
                Expect(exc, Is.SameAs(exception));
            }
        }

        [Test]
        public void it_can_be_caught_as_a_domain_exception()
        {
            var exception = new AuthorizationException();
            try
            {
                throw exception;
            }
            catch (DomainException exc)
            {
                Expect(exc, Is.SameAs(exception));
            }
        }

    }
}
