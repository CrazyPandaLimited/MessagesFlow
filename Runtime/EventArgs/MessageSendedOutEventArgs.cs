using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace UnityCore.MessagesFlow
{
    public class MessageSendedOutEventArgs : EventArgs
    {
        #region Properties
        public MessageHeader Header { get; private set; }
        public IMessageBody Body { get; private set; }
        #endregion

        #region Constructors
        public MessageSendedOutEventArgs( MessageHeader header, IMessageBody body )
        {
            Header = header;
            Body = body;
        }
        #endregion
    }
}
