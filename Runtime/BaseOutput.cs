using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public enum OutputHandlingType
    {
        /// <summary>
        /// Throws exception, if not connected to input
        /// </summary>
        ConnectionRequired,

        /// <summary>
        /// Does nothing, if not connected to input
        /// </summary>
        Optional,
    }

    public class BaseOutput<T> : IOutputNode<T>
        where T : IMessageBody
    {
        private IInputNode<T> _linkedInput;
        private EventHandler< MessageSentOutEventArgs > _messageSent;
        private readonly OutputHandlingType _outputHandlingType;

        event EventHandler< MessageSentOutEventArgs > IOutputNode.MessageSent
        {
            add { _messageSent += value; }
            remove { _messageSent -= value; }
        }

        public BaseOutput( OutputHandlingType outputHandlingType = OutputHandlingType.ConnectionRequired )
        {
            _outputHandlingType = outputHandlingType;
        }

        public void LinkTo( IInputNode<T> input )
        {
            _linkedInput = input;
        }

        public void ProcessMessage( MessageHeader header, T body )
        {
            _messageSent?.Invoke( this, new MessageSentOutEventArgs( header, body ) );

            if( _linkedInput == null )
            {
                if( _outputHandlingType == OutputHandlingType.ConnectionRequired )
                    throw new InvalidOperationException( "BaseOuput must be linked to IInputNode" );
            }
            else
            {
                _linkedInput.ProcessMessage( header, body );
            }
        }
    }
}
