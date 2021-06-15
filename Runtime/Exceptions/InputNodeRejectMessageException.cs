using System;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public class InputNodeRejectMessageException : Exception
    {
        public InputNodeRejectMessageException( string message ) : base( message )
        {
        }

        public InputNodeRejectMessageException( string message, Exception innerException ) : base( message, innerException )
        {
        }
    }
}
