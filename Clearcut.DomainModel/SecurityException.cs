using System;
using System.Runtime.Serialization;

namespace Clearcut.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class SecurityException : DomainException
    {
        // constructors...
        #region SecurityException()
        /// <summary>
        /// Constructs a new SecurityException.
        /// </summary>
        public SecurityException() { }
        #endregion
        #region SecurityException(string message)
        /// <summary>
        /// Constructs a new SecurityException.
        /// </summary>
        /// <param name="message">The exception message</param>
        public SecurityException(string message) : base(message) { }
        #endregion
        #region SecurityException(string message, Exception innerException)
        /// <summary>
        /// Constructs a new SecurityException.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public SecurityException(string message, Exception innerException) : base(message, innerException) { }
        #endregion
        #region SecurityException(SerializationInfo info, StreamingContext context)
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        protected SecurityException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion
    }
}
