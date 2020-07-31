using System;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public class InputNodeRejectMessageException : Exception
    {
        #region Constructors
        public InputNodeRejectMessageException( string message ) : base( message )
        {
        }

        public InputNodeRejectMessageException( string message, Exception innerException ) : base( message, innerException )
        {
        }
        #endregion
    }
}
