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

        public void Add( T item )
        {
            _values[_count++] = item;
        }
    }
}
