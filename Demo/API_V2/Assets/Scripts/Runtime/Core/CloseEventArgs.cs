using System;

namespace UnityWebSocket
{
    /// <summary>
    /// Represents the event data for the <see cref="IWebSocket.OnClose"/> event.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   That event occurs when the WebSocket connection has been closed.
    ///   </para>
    ///   <para>
    ///   If you would like to get the reason for the close, you should access
    ///   the <see cref="Code"/> or <see cref="Reason"/> property.
    ///   </para>
    /// </remarks>
    public class CloseEventArgs : EventArgs
    {
        #region Internal Constructors

        internal CloseEventArgs()
        {
        }

        internal CloseEventArgs(ushort code)
          : this(code, null)
        {
        }

        internal CloseEventArgs(CloseStatusCode code)
          : this((ushort)code, null)
        {
        }

        internal CloseEventArgs(CloseStatusCode code, string reason)
          : this((ushort)code, reason)
        {
        }

        internal CloseEventArgs(ushort code, string reason)
        {
            Code = code;
            Reason = reason;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the status code for the close.
        /// </summary>
        /// <value>
        /// A <see cref="ushort"/> that represents the status code for the close if any.
        /// </value>
        public ushort Code { get; private set; }

        /// <summary>
        /// Gets the reason for the close.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that represents the reason for the close if any.
        /// </value>
        public string Reason { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the connection has been closed cleanly.
        /// </summary>
        /// <value>
        /// <c>true</c> if the connection has been closed cleanly; otherwise, <c>false</c>.
        /// </value>
        public bool WasClean { get; internal set; }

        /// <summary>
        /// Enum value same as Code
        /// </summary>
        public CloseStatusCode StatusCode
        {
            get
            {
                if (Enum.IsDefined(typeof(CloseStatusCode), Code))
                    return (CloseStatusCode)Code;
                return CloseStatusCode.Unknown;
            }
        }

        #endregion
    }
}
