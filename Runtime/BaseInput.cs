using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public class BaseInput< T > : IInputNode< T >
        where T : IMessageBody
    {
        private EventHandler< MessageReceivedEventArgs > _messageReceived;

        event EventHandler< MessageReceivedEventArgs > IInputNode.MessageReceived
        {
            add { _messageReceived += value; }
            remove { _messageReceived -= value; }
        }

        public event Action< MessageHeader, T > MessageReceived;

        public BaseInput( Action< MessageHeader, T > receivedCallback )
        {
            MessageReceived += receivedCallback;
        }

        public void ProcessMessage( MessageHeader header, T body )
        {
            var args = new MessageReceivedEventArgs( header, body );
            _messageReceived?.Invoke( this, args );

            MessageReceived?.Invoke( header, body );
        }
    }
}
