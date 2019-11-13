using System;

namespace UnityCore.MessagesFlow
{
    public abstract class InputNode< TBodyType > : IInputNode< TBodyType >
    {
        #region Properties
        public FlowNodeStatus Status { get; protected set; }
        public AggregateException Exception { get; protected set; }
        #endregion

        #region Events
        public event EventHandler< MessageConsumedEventArgs > OnMessageConsumed = delegate { };
        public event EventHandler< FlowNodeStatusChangedEventArgs > OnStatusChanged = delegate { };
        #endregion

        #region Public Members
        public abstract FlowMessageStatus ProcessMessage( MessageHeader header, TBodyType body );

        public void Restore()
        {
        }

        public void Dispose()
        {
        }
        #endregion
    }
}
