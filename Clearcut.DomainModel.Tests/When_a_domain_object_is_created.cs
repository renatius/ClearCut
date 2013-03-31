using System;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_a_domain_object_is_created : AssertionHelper
    {
        class MinimalObject : DomainObject
        {
            public int RegisterConstraintsCalled { get; private set; }

            protected override void RegisterConstraints()
            {
                RegisterConstraintsCalled += 1;
            }
        }

        [Test]
        public void register_constraints_is_called_exactly_once()
        {
            var obj = new MinimalObject();
            Expect(obj.RegisterConstraintsCalled, Is.EqualTo(1));
        }

    }
}
