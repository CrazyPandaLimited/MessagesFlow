using System;
using System.Collections.Generic;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public interface IFlowNode
    {
        FlowNodeStatus Status { get; }
        Exception Exception { get; }

        IReadOnlyCollection< IInputNode > Inputs { get; }
        IReadOnlyCollection< IOutputNode > Outputs { get; }

        event EventHandler< FlowNodeStatusChangedEventArgs > OnStatusChanged;

        void Restore();
    }
}
