using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Collections
{
    public class MyList<T>
    {
        T[] _values;
        int _count;

        public MyList()
        {
            _values = new T[4];
        }

        public int Count => _count;

        public T this[int idx]
        {
            get
            {
                if( idx < 0 || idx >= _count ) throw new IndexOutOfRangeException();
                return _values[idx];
            }
            set
            {
                if( idx < 0 || idx >= _count ) throw new IndexOutOfRangeException();
                _values[idx] = value;
            }
        }

        public void Clear()
        {
            if( _count > 0 )
            {
                if( !typeof(T).IsValueType )
                {
                    Array.Clear( _values, 0, _count );
                }
                _count = 0;
            }
        }

        public void Add( T item )
        {
            if( ++_count == _values.Length )
            {
                Array.Resize( ref _values, _count * 2 );
            }
            _values[_count-1] = item;
        }
    }
}
