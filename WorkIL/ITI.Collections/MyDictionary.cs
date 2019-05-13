using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Collections
{
    public class MyDictionary<TKey,TValue>
    {
        int _count;

        public int Count => _count;

        public void Add( TKey key, TValue value )
        {
        }

        public TValue this[ TKey key ]
        {
            get => default( TValue );
            set => throw new NotImplementedException();
        }
    }
}
