using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Collections
{
    public class MyDictionary<TKey,TValue>
    {
        int _count;
        Node[] _buckets;

        class Node
        {
            public readonly TKey Key;
            public TValue Value;
            public Node Next;

            public Node( TKey k ) => Key = k;
        }

        public MyDictionary()
        {
            _buckets = new Node[11]; 
        }

        public int Count => _count;

        public void Remove( TKey key )
        {

        }

        int GetHashCode( TKey key ) => Math.Abs( key.GetHashCode() );

        bool Equals( TKey k1, TKey k2 ) => k1.Equals( k2 );

        public void Add( TKey key, TValue value )
        {
            int h = GetHashCode( key );
            int idx = h % _buckets.Length;
            Node n = FindInBucket( key, idx );
            if( n != null ) throw new InvalidOperationException();
            else AddNewKeyValue( key, value, h, idx );
        }

        public TValue this[ TKey key ]
        {
            get
            {
                int h = GetHashCode( key );
                int idx = h % _buckets.Length;
                Node n = FindInBucket( key, idx );
                if( n != null ) return n.Value;
                throw new KeyNotFoundException();
            }
            set
            {
                int h = GetHashCode( key );
                int idx = h % _buckets.Length;
                Node n = FindInBucket( key, idx );
                if( n != null )
                {
                    n.Value = value;
                }
                else AddNewKeyValue( key, value, h, idx );
            }
        }

        void AddNewKeyValue( TKey key, TValue value, int hashCode, int currentIdx )
        {
            int fillFactor = _count / _buckets.Length;
            if( fillFactor > 20 )
            {
                Grow();
                currentIdx = hashCode % _buckets.Length;
            }
            _count++;
            _buckets[currentIdx] = new Node( key )
            {
                Value = value,
                Next = _buckets[currentIdx]
            };
        }

        Node FindInBucket( TKey key, int idx )
        {
            Node n = _buckets[idx];
            while( n != null )
            {
                if( Equals( n.Key, key ) ) break;
                n = n.Next;
            }
            return n;
        }

        void Grow()
        {
            int newLength = NextPrimeNumber( _buckets.Length );

        }

        static int NextPrimeNumber( int length )
        {
            return length * 2;
        }
    }
}
