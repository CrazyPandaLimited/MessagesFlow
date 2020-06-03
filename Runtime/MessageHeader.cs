﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace UnityCore.MessagesFlow
{
    public class MessageHeader
    {
        private List<Exception> _exceptions = null;

        #region Properties
        public string Id { get; protected set; }
        public MetaData MetaData { get; protected set; }

        public CancellationToken CancellationToken { get; protected set; }

        public AggregateException Exceptions => _exceptions == null ? null : new AggregateException( _exceptions );

        public IReadOnlyList<Exception> ExceptionsList => _exceptions;
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
            if( _exceptions == null )
            {
                _exceptions = new List< Exception >( 1 ) { exception };
            }
            else
            {
                _exceptions.Add( exception );
            }
        }

        public override string ToString()
        {
            return $"Id:{Id} IsCanceled:{CancellationToken.IsCancellationRequested} Metadata:{MetaData} Exceptions:{Exceptions?.ToString()}";
        }
        #endregion
    }
}
