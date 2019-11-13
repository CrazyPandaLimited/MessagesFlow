using System;
using CrazyPanda.UnityCore.AssetsSystem;

namespace UnityCore.MessagesFlow
{
    public interface IOutputConnection< out TBodyType > : IBaseOutputConnection where TBodyType : IMessageBody
    {
        void SetConnection( IInputNode< TBodyType > inputNode );
    }
    
    /// <summary>
    /// Fields for non generic use
    /// </summary>
    public interface IBaseOutputConnection
    {
        event EventHandler< MessageSendedOutEventArgs > OnMessageSended;
    }
}
