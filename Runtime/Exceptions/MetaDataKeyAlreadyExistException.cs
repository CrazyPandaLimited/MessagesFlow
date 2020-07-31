using System;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public class MetaDataKeyAlreadyExistException : Exception
    {
        #region Constructors
        public MetaDataKeyAlreadyExistException( string message ) : base( message )
        {
        }
        #endregion
    }
}
