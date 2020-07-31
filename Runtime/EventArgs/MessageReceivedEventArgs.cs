using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public struct MessageReceivedEventArgs
    {
        public MessageHeader Header { get; }
        public IMessageBody Body { get; }

        public MessageReceivedEventArgs( MessageHeader header, IMessageBody body )
        {
            Header = header ?? throw new ArgumentNullException( nameof( header ) );
            Body = body ?? throw new ArgumentNullException( nameof( body ) );
        }
    }
}
