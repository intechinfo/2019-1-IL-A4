using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITI.Collections
{
    public enum KrabouilleMode
    {
        Krabouille,
        Unkrabouille
    }

    public class KrabouilleStream : Stream
    {
        static readonly byte[] _salt = Encoding.UTF7.GetBytes( "My salt is somehow public..." );

        readonly Stream _inner;
        readonly byte[] _secret;
        int _pos;
        readonly Random _rnd;

        public KrabouilleStream( Stream innerStream, string passPhrase, KrabouilleMode mode )
        {
            _inner = innerStream;
            using( var d = new System.Security.Cryptography.Rfc2898DeriveBytes( passPhrase, _salt ) )
            {
                _secret = d.GetBytes(111);
                var fourBytes = d.GetBytes( 4 );
                int seed = fourBytes[0];
                seed |= fourBytes[1] << 8;
                seed |= fourBytes[2] << 16;
                seed |= fourBytes[3] << 24;
                _rnd = new Random( seed );
            }
        }

        /// <summary>
        /// Gets the inner stream.
        /// </summary>
        public Stream InnerStream => _inner;

        public override bool CanRead => _inner.CanRead;

        public override bool CanWrite => _inner.CanWrite;

        public override bool CanSeek => _inner.CanSeek;

        public override long Length => _inner.Length;

        public override long Position
        {
            get => _inner.Position;
            set => _inner.Position = value;
        }

        public override void Flush()
        {
            _inner.Flush();
        }

        public override int Read( byte[] buffer, int offset, int count )
        {
            int len = _inner.Read( buffer, offset, count );
            for( int i = 0; i < len; ++i )
            {
                buffer[offset + i] ^= (byte)(_secret[_pos++] ^ _rnd.Next());
                if( _pos == _secret.Length ) _pos = 0;
            }
            return len;
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            return _inner.Seek( offset, origin );
        }

        public override void SetLength( long value )
        {
            _inner.SetLength( value );
        }

        public override void Write( byte[] buffer, int offset, int count )
        {
            for( int i = 0; i < count; ++i )
            {
                buffer[offset + i] ^= (byte)(_secret[_pos++] ^ _rnd.Next());
                if( _pos == _secret.Length ) _pos = 0;
            }
            _inner.Write( buffer, offset, count );
        }
    }
}
