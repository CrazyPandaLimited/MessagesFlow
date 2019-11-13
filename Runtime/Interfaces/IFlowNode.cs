using System;

namespace UnityCore.MessagesFlow
{
    public interface IFlowNode
    {
        #region Properties
        FlowNodeStatus Status { get; }
        AggregateException Exception { get; }
        #endregion

        #region Events
        event EventHandler< FlowNodeStatusChangedEventArgs > OnStatusChanged;
        #endregion

        #region Public Members
        void Restore();
        #endregion
    }
}
