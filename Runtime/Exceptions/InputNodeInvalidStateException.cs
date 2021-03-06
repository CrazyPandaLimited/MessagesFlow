using System;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public class InputNodeInvalidStateException : Exception
    {
        public InputNodeInvalidStateException( string message ) : base( message )
        {
        }

        public InputNodeInvalidStateException( string message, Exception innerException ) : base( message, innerException )
        {
        }
    }
}
