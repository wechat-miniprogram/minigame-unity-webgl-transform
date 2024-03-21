using System;

namespace UnityWebSocket
{
    /// <summary>
    /// Represents the event data for the <see cref="IWebSocket.OnError"/> event.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   That event occurs when the <see cref="IWebSocket"/> gets an error.
    ///   </para>
    ///   <para>
    ///   If you would like to get the error message, you should access
    ///   the <see cref="Message"/> property.
    ///   </para>
    ///   <para>
    ///   And if the error is due to an exception, you can get it by accessing
    ///   the <see cref="Exception"/> property.
    ///   </para>
    /// </remarks>
    public class ErrorEventArgs : EventArgs
    {
        #region Internal Constructors

        internal ErrorEventArgs(string message)
          : this(message, null)
        {
        }

        internal ErrorEventArgs(string message, Exception exception)
        {
            this.Message = message;
            this.Exception = exception;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the exception that caused the error.
        /// </summary>
        /// <value>
        /// An <see cref="System.Exception"/> instance that represents the cause of
        /// the error if it is due to an exception; otherwise, <see langword="null"/>.
        /// </value>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that represents the error message.
        /// </value>
        public string Message { get; private set; }

        #endregion
    }
}
