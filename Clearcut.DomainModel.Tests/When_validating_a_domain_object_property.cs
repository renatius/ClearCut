using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_validating_a_domain_object_property : AssertionHelper
    {
        class PropertyValidation : DomainObject
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }

            public List<int> ExecutionList { get; private set; }

            public PropertyValidation() { ExecutionList = new List<int>(); }

            protected override void RegisterConstraints()
            {
                Requires(() => { ExecuteConstraint(1); return true; },
                    null, "Error 1");
                Requires(() => { ExecuteConstraint(2); return true; },
                    "A", "Error 2");
                Requires(() => { ExecuteConstraint(3); return true; },
                    null, "Error 3");
                Requires(() => { ExecuteConstraint(4); return true; },
                    "B", "Error 4");
                Requires(() => { ExecuteConstraint(5); return true; },
                    null, "Error 5");
                Requires(() => { ExecuteConstraint(6); return true; },
                    "A", "Error 6");
                Requires(() => { ExecuteConstraint(7); return true; },
                    null, "Error 7");
            }

            private void ExecuteConstraint(int n)
            {
                ExecutionList.Add(n);
            }
        }

        [Test]
        public void constraints_are_executed_in_order_of_registration()
        {
            int[] expected = { 2, 6 };
            var obj = new PropertyValidation();
            obj.Validate("A");

            Expect(obj.ExecutionList.Count, Is.EqualTo(expected.Length));

            for (int i = 0; i < expected.Length; i++)
            {
                Expect(obj.ExecutionList[i], Is.EqualTo(expected[i]));
            }
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void if_property_name_is_null_a_domain_exception_is_raised()
        {
            var obj = new PropertyValidation();
            obj.Validate(null);
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void if_property_name_is_empty_a_domain_exception_is_raised()
        {
            var obj = new PropertyValidation();
            obj.Validate("");
        }

        [Test]
        public void if_no_constraints_registered_no_exception_is_raised()
        {
            var obj = new PropertyValidation();
            obj.Validate("C");
            Expect(true);
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void if_property_does_not_exists_a_domain_exception_is_raised()
        {
            var obj = new PropertyValidation();
            obj.Validate("Z");
        }
    }
}
