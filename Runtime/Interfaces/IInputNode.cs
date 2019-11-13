using System;

namespace UnityCore.MessagesFlow
{
    public interface IInputNode< in TBodyType > : IInputNode
    {
        #region Public Members
        FlowMessageStatus ProcessMessage( MessageHeader header, TBodyType body );
        #endregion
    }

    public interface IInputNode : IFlowNode, IDisposable
    {
        event EventHandler< MessageConsumedEventArgs > OnMessageConsumed;
    }
}
