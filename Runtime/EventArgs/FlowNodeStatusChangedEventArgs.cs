using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace UnityCore.MessagesFlow
{
    public class FlowNodeStatusChangedEventArgs : EventArgs
    {
        #region Public Fields
        public IFlowNode Node;
        public FlowNodeStatus NewStatus;
        public MessageHeader Header;
        public IMessageBody Body;
        #endregion

        #region Constructors
        public FlowNodeStatusChangedEventArgs( IFlowNode node, FlowNodeStatus newStatus )
        {
            Node = node;
            NewStatus = newStatus;
            Header = null;
        }

        public FlowNodeStatusChangedEventArgs( IFlowNode node, MessageHeader header, IMessageBody body, FlowNodeStatus newStatus )
        {
            Node = node;
            NewStatus = newStatus;
            Header = header;
            Body = body;
        }
        #endregion
    }
}
