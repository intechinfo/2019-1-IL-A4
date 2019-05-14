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

        public void Add( TKey key, TValue value )
        {

        }

        public TValue this[ TKey key ]
        {
            get
            {

            }
            set
            {
                int h = key.GetHashCode();
                int idx = h % _buckets.Length;
                Node n = _buckets[idx];
                while( n != null )
                {
                    if( n.Key.Equals( key ) )
                    {
                        n.Value = value;
                        return;
                    }
                    n = n.Next;
                }
                int fillFactor = _count / _buckets.Length;
                if( fillFactor > 20 )
                {
                    Grow();
                    idx = h % _buckets.Length;
                }
                _count++;
                _buckets[idx] = new Node( key )
                {
                    Value = value,
                    Next = _buckets[idx]
                };
            }
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
