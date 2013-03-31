using System;
using System.Collections.Generic;
using Clearcut.DomainModel.Internal;

namespace Clearcut.DomainModel
{
    public abstract class DomainObject
    {
        private readonly List<Constraint> constraints = new List<Constraint>();

        protected DomainObject()
        {
            RegisterConstraints();
        }

        protected abstract void RegisterConstraints();

        protected void Requires(Func<bool> predicate, string targetProperty, string errorMessage)
        {
            Precondition.Requires(
                predicate != null,
                Properties.Resources.CONSTRAINT_REGISTRATION_PREDICATE_CANNOT_BE_NULL
                );

            Precondition.Requires(
                targetProperty == null || Internal.ReflectionHelper.PropertyExists(GetType(), targetProperty),
                Properties.Resources.CONSTRAINT_REGISTRATION_PROPERTY_MUST_EXISTS
                );

            Precondition.Requires(
                errorMessage != null,
                Properties.Resources.CONSTRAINT_REGISTRATION_ERROR_MESSAGE_CANNOT_BE_NULL
                );

            constraints.Add(new Constraint(predicate, targetProperty, errorMessage));
        }

        public virtual void Validate()
        {
            constraints.ForEach(r => r.Validate());
        }

        public virtual void Validate(string propertyName)
        {
            Precondition.Requires(
                propertyName != null,
                Properties.Resources.DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_CANNOT_BE_NULL);

            Precondition.Requires(
                propertyName.Trim() != string.Empty,
                Properties.Resources.DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_CANNOT_BE_ALL_BLANKS);

            Precondition.Requires(
                Internal.ReflectionHelper.PropertyExists(GetType(), propertyName),
                Properties.Resources.DOMAIN_OBJECT_VALIDATE_PROPERTY_NAME_MUST_EXIST
                );

            var rules = constraints.FindAll(r => r.TargetProperty == propertyName);
            rules.ForEach(r => r.Validate());
        }
    }
}
