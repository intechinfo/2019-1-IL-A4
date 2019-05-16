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
        readonly Stream _inner;

        public KrabouilleStream( Stream innerStream, string passPhrase, KrabouilleMode mode )
        {
            _inner = innerStream;
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
            return _inner.Read( buffer, offset, count );
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
            _inner.Write( buffer, offset, count );
        }
    }
}
