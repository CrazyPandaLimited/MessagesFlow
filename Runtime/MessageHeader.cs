using System;
using System.Threading;

namespace UnityCore.MessagesFlow
{
    public class MessageHeader
    {
        #region Properties
        public string Id { get; protected set; }
        public MetaData MetaData { get; protected set; }

        public CancellationToken CancellationToken { get; protected set; }

        public AggregateException Exceptions { get; protected set; }
        #endregion

        #region Constructors
        public MessageHeader( MetaData metaData, CancellationToken cancellationToken )
        {
            Id = Guid.NewGuid().ToString();
            MetaData = metaData;
            CancellationToken = cancellationToken;
        }
        #endregion

        #region Public Members
        public void AddException( Exception exception )
        {
            Exceptions = Exceptions == null ? new AggregateException( exception ) : new AggregateException( exception, Exceptions );
        }


        public override string ToString()
        {
            return $"Id:{Id} IsCanceled:{CancellationToken.IsCancellationRequested} Metadata:{MetaData} Exceptions:{Exceptions?.Flatten().ToString()}";
        }
        #endregion
    }
}
