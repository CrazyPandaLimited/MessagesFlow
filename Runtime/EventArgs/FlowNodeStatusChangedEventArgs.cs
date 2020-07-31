using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public struct FlowNodeStatusChangedEventArgs
    {
        public IFlowNode Node { get; }
        public FlowNodeStatus NewStatus { get; }
        public MessageHeader Header { get; }
        public IMessageBody Body { get; }

        public FlowNodeStatusChangedEventArgs( IFlowNode node, FlowNodeStatus newStatus )
            : this( node, newStatus, null, null )
        {
        }

        public FlowNodeStatusChangedEventArgs( IFlowNode node, FlowNodeStatus newStatus, MessageHeader header, IMessageBody body )
        {
            Node = node ?? throw new ArgumentNullException( nameof( node ) );
            NewStatus = newStatus;
            Header = header;
            Body = body;
        }
    }
}
