using System;
using System.Runtime.Serialization;

namespace Clearcut.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DomainException : Exception
    {
        // constructors...
        #region DomainException()
        /// <summary>
        /// Constructs a new DomainException.
        /// </summary>
        public DomainException() { }
        #endregion
        #region DomainException(string message)
        /// <summary>
        /// Constructs a new DomainException.
        /// </summary>
        /// <param name="message">The exception message</param>
        public DomainException(string message) : base(message) { }
        #endregion
        #region DomainException(string message, Exception innerException)
        /// <summary>
        /// Constructs a new DomainException.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
        #endregion
        #region DomainException(SerializationInfo info, StreamingContext context)
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion
    }
}
