using System;

namespace UnityWebSocket
{
    /// <summary>
    /// <para>IWebSocket indicate a network connection.</para>
    /// <para>It can be connecting, connected, closing or closed state. </para>
    /// <para>You can send and receive messages by using it.</para>
    /// <para>Register callbacks for handling messages.</para>
    /// <para> ----------------------------------------------------------- </para>
    /// <para>IWebSocket 表示一个网络连接，</para>
    /// <para>它可以是 connecting connected closing closed 状态，</para>
    /// <para>可以发送和接收消息，</para>
    /// <para>通过注册消息回调，来处理接收到的消息。</para>
    /// </summary>
    public interface IWebSocket
    {
        /// <summary>
        /// Establishes a connection asynchronously.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///   This method does not wait for the connect process to be complete.
        ///   </para>
        ///   <para>
        ///   This method does nothing if the connection has already been
        ///   established.
        ///   </para>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///   <para>
        ///   This instance is not a client.
        ///   </para>
        ///   <para>
        ///   -or-
        ///   </para>
        ///   <para>
        ///   The close process is in progress.
        ///   </para>
        ///   <para>
        ///   -or-
        ///   </para>
        ///   <para>
        ///   A series of reconnecting has failed.
        ///   </para>
        /// </exception>
        void ConnectAsync();

        /// <summary>
        /// Closes the connection asynchronously.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///   This method does not wait for the close to be complete.
        ///   </para>
        ///   <para>
        ///   This method does nothing if the current state of the connection is
        ///   Closing or Closed.
        ///   </para>
        /// </remarks>
        void CloseAsync();

        /// <summary>
        /// Sends the specified data asynchronously using the WebSocket connection.
        /// </summary>
        /// <remarks>
        /// This method does not wait for the send to be complete.
        /// </remarks>
        /// <param name="data">
        /// An array of <see cref="byte"/> that represents the binary data to send.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// The current state of the connection is not Open.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="data"/> is <see langword="null"/>.
        /// </exception>
        void SendAsync(byte[] data);

        /// <summary>
        /// Sends the specified data using the WebSocket connection.
        /// </summary>
        /// <param name="text">
        /// A <see cref="string"/> that represents the text data to send.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// The current state of the connection is not Open.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="text"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="text"/> could not be UTF-8 encoded.
        /// </exception>
        void SendAsync(string text);

        /// <summary>
        /// get the address which to connect.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Gets the current state of the connection.
        /// </summary>
        /// <value>
        ///   <para>
        ///   One of the <see cref="WebSocketState"/> enum values.
        ///   </para>
        ///   <para>
        ///   It indicates the current state of the connection.
        ///   </para>
        ///   <para>
        ///   The default value is <see cref="WebSocketState.Connecting"/>.
        ///   </para>
        /// </value>
        WebSocketState ReadyState { get; }

        /// <summary>
        /// Occurs when the WebSocket connection has been established.
        /// </summary>
        event EventHandler<OpenEventArgs> OnOpen;

        /// <summary>
        /// Occurs when the WebSocket connection has been closed.
        /// </summary>
        event EventHandler<CloseEventArgs> OnClose;

        /// <summary>
        /// Occurs when the <see cref="IWebSocket"/> gets an error.
        /// </summary>
        event EventHandler<ErrorEventArgs> OnError;

        /// <summary>
        /// Occurs when the <see cref="IWebSocket"/> receives a message.
        /// </summary>
        event EventHandler<MessageEventArgs> OnMessage;
    }
}
