using System;
using System.Collections.Generic;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public interface IInputNode
    {
        event EventHandler< MessageReceivedEventArgs > MessageReceived;
    }

    public interface IInputNode< in TBodyType > : IInputNode
    {
        void ProcessMessage( MessageHeader header, TBodyType body );
    }
}
