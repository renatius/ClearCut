using System;
using System.Runtime.Serialization;

namespace Clearcut.DomainModel
{
    [Serializable]
    public class AuthorizationException : SecurityException
    {
        // constructors...
        #region AuthorizationException()
        /// <summary>
        /// Constructs a new AuthorizationException.
        /// </summary>
        public AuthorizationException() { }
        #endregion
        #region AuthorizationException(string message)
        /// <summary>
        /// Constructs a new AuthorizationException.
        /// </summary>
        /// <param name="message">The exception message</param>
        public AuthorizationException(string message) : base(message) { }
        #endregion
        #region AuthorizationException(string message, Exception innerException)
        /// <summary>
        /// Constructs a new AuthorizationException.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public AuthorizationException(string message, Exception innerException) : base(message, innerException) { }
        #endregion
        #region AuthorizationException(SerializationInfo info, StreamingContext context)
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion
    }
}
