using System;
using System.Collections.Generic;

namespace UnityCore.MessagesFlow
{
    public class MetaData
    {
        #region Private Fields
        private Dictionary< string, KeyValuePair< Type, object > > _metadata = new Dictionary< string, KeyValuePair< Type, object > >();
        private HashSet< string > _flags = new HashSet< string >();
        #endregion

        #region Constructors
        public MetaData()
        {
        }

        public MetaData( params string[ ] flags )
        {
            foreach( var flag in flags )
            {
                SetFlag( flag );
            }
        }
        #endregion

        #region Public Members
        public MetaData Copy()
        {
            var newMetaData = new MetaData();

            foreach( var keyValuePair in _metadata )
            {
                newMetaData._metadata.Add( keyValuePair.Key, keyValuePair.Value );
            }

            foreach( var flag in _flags )
            {
                newMetaData._flags.Add( flag );
            }

            return newMetaData;
        }

        public bool IsMetaExist( string key )
        {
            if( string.IsNullOrEmpty( key ) )
            {
                throw new ArgumentNullException( nameof(key) );
            }

            return _metadata.ContainsKey( key );
        }


        public T GetMeta< T >( string key )
        {
            if( !_metadata.ContainsKey( key ) )
            {
                throw new KeyNotFoundException( key );
            }

            if (!(_metadata[key].Value is T))
            {
                throw new InvalidCastException( key );
            }

            return ( T ) _metadata[ key ].Value;
        }


        public void SetMeta< T >( string key, T data, bool overrideData = false )
        {
            if( _metadata.ContainsKey( key ) )
            {
                if( overrideData )
                {
                    _metadata[ key ] = new KeyValuePair< Type, object >( typeof( T ), data );
                    return;
                }

                throw new MetaDataKeyAlreadyExistException( $"For key:{key}" );
            }

            _metadata.Add( key, new KeyValuePair< Type, object >( typeof( T ), data ) );
        }

        public bool HasFlag( string flag )
        {
            return _flags.Contains( flag );
        }

        public void SetFlag( string flag )
        {
            _flags.Add( flag );
        }

        public void RemoveFlag( string flag )
        {
            _flags.Remove( flag );
        }

        public override string ToString()
        {
            string result = "MetaData:";
            foreach( var o in _metadata )
            {
                result += $"key:{o.Key} value:{o.Value.ToString()} ";
            }

            foreach( var o in _flags )
            {
                result += $" flag:{o}";
            }

            result += "/MetaDataEnd/";
            return result;
        }
        #endregion
    }
}
