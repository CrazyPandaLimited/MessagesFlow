using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace UnityCore.MessagesFlow
{
    public class NodeOutputConnection< TBodyType > : IOutputConnection< TBodyType > where TBodyType : IMessageBody
    {
        #region Protected Fields
        protected IInputNode< TBodyType > _connectedNode;
        #endregion

        #region Events
        public event EventHandler< MessageSendedOutEventArgs > OnMessageSended = delegate { };
        #endregion

        #region Constructors
        public NodeOutputConnection( IInputNode< TBodyType > connectedNode )
        {
            _connectedNode = connectedNode;
        }

        public NodeOutputConnection()
        {
        }
        #endregion

        #region Public Members
        public void SetConnection( IInputNode< TBodyType > inputNode )
        {
            _connectedNode = inputNode;
        }

        public void ProcessMessage( MessageHeader header, TBodyType body )
        {
            if( _connectedNode.Status == FlowNodeStatus.Failed )
            {
                throw new InputNodeInvalidStateException( _connectedNode.GetType().ToString() );
            }

            OnMessageSended.Invoke( this, new MessageSendedOutEventArgs( header, body ) );

            _connectedNode.ProcessMessage( header, body );
        }
        #endregion
    }
}
