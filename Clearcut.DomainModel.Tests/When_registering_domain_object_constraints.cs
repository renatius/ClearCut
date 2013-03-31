using System;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_registering_domain_object_constraints : AssertionHelper
    {
        class NullPredicate : DomainObject
        {
            protected override void RegisterConstraints()
            {
                Requires(null, null, "Error");
            }
        }

        class NullErrorMessage : DomainObject
        {
            protected override void RegisterConstraints()
            {
                Requires(() => true, null, null);
            }
        }

        class NullPropertyName : DomainObject
        {
            protected override void RegisterConstraints()
            {
                Requires(() => true, null, "Error");
            }
        }

        class NonExistentProperty : DomainObject
        {
            protected override void RegisterConstraints()
            {
                Requires(() => true, "A", "Error");
            }
        }

        class BaseClass : DomainObject
        {
            protected string A { get; set; }
            protected static int B { get; set; }
            public double D { get { return 0; } }
            public static bool C { get { return false; } }
            protected override void RegisterConstraints()
            {
                Requires(() => true, null, "Base");
            }
        }

        class DerivedClass : BaseClass
        {
            protected override void RegisterConstraints()
            {
                base.RegisterConstraints();
                Requires(() => true, "A", "A");
                Requires(() => true, "B", "B");
                Requires(() => true, "C", "C");
                Requires(() => true, "D", "D");
            }
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void predicate_cannot_be_null()
        {
            new NullPredicate();
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void error_message_cannot_be_null()
        {
            new NullErrorMessage();
        }

        [Test]
        public void property_name_can_be_null()
        {
            new NullPropertyName();
            Expect(true);
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void property_name_must_correspond_to_existing_property()
        {
            new NonExistentProperty();
        }

        [Test]
        public void can_use_base_class_properties()
        {
            new DerivedClass();
            Expect(true);
        }
    }
}
