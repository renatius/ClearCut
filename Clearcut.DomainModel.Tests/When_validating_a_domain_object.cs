using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Clearcut.DomainModel.Tests
{
    [TestFixture]
    public class When_validating_a_domain_object : AssertionHelper
    {
        class NoConstraintsRegistered : DomainObject
        {
            protected override void RegisterConstraints()
            {
            }
        }

        class ExecutionOrder : DomainObject
        {
            public string A { get; set; }
            public string B { get; set; }

            public List<int> ExecutionList { get; private set; }

            public ExecutionOrder() { ExecutionList = new List<int>(); }

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

        class NotNullConstraint : DomainObject
        {
            public string A { get; set; }

            protected override void RegisterConstraints()
            {
                Requires(() => A != null, "A", "Error");
            }
        }

        [Test]
        public void if_no_constraints_have_been_registered_no_exception_is_raised()
        {
            var obj = new NoConstraintsRegistered();
            obj.Validate();
            Expect(true);
        }

        [Test]
        public void constraints_are_executed_in_order_of_registration()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7 };
            var obj = new ExecutionOrder();
            obj.Validate();

            Expect(obj.ExecutionList.Count, Is.EqualTo(expected.Length));

            for (int i = 0; i < expected.Length; i++)
            {
                Expect(obj.ExecutionList[i], Is.EqualTo(expected[i]));
            }
        }

        [Test]
        [ExpectedException(typeof(DomainException))]
        public void if_validation_fails_a_domain_exception_is_raised()
        {
            var obj = new NotNullConstraint();
            obj.Validate();
        }

        [Test]
        public void if_validation_succeeds_no_exception_is_raised()
        {
            var obj = new NotNullConstraint();
            obj.A = "hello";
            obj.Validate();
            Expect(true);
        }
    }
}
