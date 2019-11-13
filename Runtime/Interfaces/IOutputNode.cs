using System;
using System.Collections.Generic;
using CrazyPanda.UnityCore.AssetsSystem;

namespace UnityCore.MessagesFlow
{
    public interface IOutputNode< out TBodyType > : IDisposable where TBodyType : IMessageBody
    {
        #region Events
        event EventHandler< MessageSendedOutEventArgs > OnMessageSended;
        #endregion

        #region Public Members
        IEnumerable< IBaseOutputConnection > GetOutputs();
        #endregion
    }
}
