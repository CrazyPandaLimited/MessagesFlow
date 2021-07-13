using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPanda.UnityCore.MessagesFlow
{
    public class MetaData
    {
        private Dictionary<string, KeyValuePair<Type, object>> _metadata;
        private HashSet<string> _flags;

        public MetaData( params string[ ] flags )
        {
            _metadata = null;
            _flags = null;

            if( flags != null && flags.Length > 0 )
            {
                _flags = new HashSet<string>();
                _flags.UnionWith( flags );
            }
        }

        public MetaData Copy()
        {
            var newMetaData = new MetaData();

            if( _metadata != null )
            {
                newMetaData._metadata = new Dictionary<string, KeyValuePair<Type, object>>();
                foreach( var keyValuePair in _metadata )
                {
                    newMetaData._metadata.Add( keyValuePair.Key, keyValuePair.Value );
                }
            }

            if( _flags != null )
            {
                newMetaData._flags = new HashSet<string>();
                newMetaData._flags.UnionWith( _flags );
            }

            return newMetaData;
        }

        public bool IsMetaExist( string key )
        {
            if( string.IsNullOrEmpty( key ) )
            {
                throw new ArgumentNullException( nameof(key) );
            }

            return _metadata != null ? _metadata.ContainsKey( key ) : false;
        }


        public T GetMeta< T >( string key )
        {
            if( _metadata == null )
            {
                throw new KeyNotFoundException( key );
            }

            return ( T ) _metadata[ key ].Value;
        }


        public void SetMeta<T>( string key, T data, bool overrideData = false )
        {
            if( _metadata == null )
            {
                _metadata = new Dictionary<string, KeyValuePair<Type, object>>();
            }

            if( overrideData )
            {
                _metadata[ key ] = new KeyValuePair<Type, object>( typeof( T ), data );
            }
            else
            {
                _metadata.Add( key, new KeyValuePair<Type, object>( typeof( T ), data ) );
            }
        }

        public bool HasFlag( string flag )
        {
            return _flags != null && _flags.Contains( flag );
        }

        public void SetFlag( string flag )
        {
            if ( _flags == null)
            {
                _flags = new HashSet<string>();
            }

            _flags.Add( flag );
        }

        public void RemoveFlag( string flag )
        {
            if( _flags != null )
            {
                _flags.Remove( flag );
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder( "MetaData:" );
            if( _metadata != null )
            {
                foreach( var o in _metadata )
                {
                    sb.Append( $"key:{o.Key} value:{o.Value} ");
                }
            }

            if( _flags != null )
            {
                foreach( var o in _flags )
                {
                    sb.Append( $" flag:{o}" );
                }
            }

            sb.Append( "/MetaDataEnd/");
            return sb.ToString();
        }
    }
}
