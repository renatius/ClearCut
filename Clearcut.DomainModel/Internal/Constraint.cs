using System;

namespace Clearcut.DomainModel.Internal
{

    internal class Constraint
    {
        private Func<bool> predicate;
        private string errorMessage;
        private string targetProperty;

        public string TargetProperty
        {
            get { return targetProperty; }
        }

        public Constraint(Func<bool> predicate, string targetProperty, string errorMessage)
        {
            this.predicate = predicate;
            this.errorMessage = errorMessage;
            this.targetProperty = targetProperty;
        }

        public void Validate()
        {
            try
            {
                if (!predicate())
                    throw new DomainException(errorMessage);
            }
            catch (DomainException)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw new DomainException(exc.Message, exc);
            }
        }
    }
}
