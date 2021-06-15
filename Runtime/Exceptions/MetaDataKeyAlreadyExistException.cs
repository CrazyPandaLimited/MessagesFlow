using System;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public class MetaDataKeyAlreadyExistException : Exception
    {
        public MetaDataKeyAlreadyExistException( string message ) : base( message )
        {
        }
    }
}
