using System;
using System.Collections.Generic;
using CrazyPanda.UnityCore.AssetsSystem;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public interface IOutputNode
    {
        event EventHandler< MessageSentOutEventArgs > MessageSent;
    }

    public interface IOutputNode< out TBodyType > : IOutputNode
        where TBodyType : IMessageBody
    {
        void LinkTo( IInputNode< TBodyType> input );
    }
}
