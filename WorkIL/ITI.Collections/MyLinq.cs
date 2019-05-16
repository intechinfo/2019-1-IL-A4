using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Collections
{
    public static class MyLinq
    {
        public static IEnumerable<T> Where<T>( this IEnumerable<T> list, Func<T, bool> predicate )
        {
            foreach( var e in list )
            {
                if( predicate( e ) ) yield return e;
            }
        }

        public static IEnumerable<T2> Select<T1, T2>( this IEnumerable<T1> list, Func<T1, T2> projection )
        {
            foreach( var e in list )
            {
                yield return projection( e );
            }
        }

        public static bool Any<T>( this IEnumerable<T> list )
        {
            using( var e = list.GetEnumerator() )
            {
                return e.MoveNext();
            }
        }

        public static int Count<T>( this IEnumerable<T> list )
        {
            int count = 0;
            using( var e = list.GetEnumerator() )
            {
                ++count;
                e.MoveNext();
            }
            return count;
        }

        public static int? Max( this IEnumerable<int> list )
        {
            int? m = null;
            foreach( var e in list )
            {
                if( m == null || m.Value < e ) m = e;
            }
            return m;
        }


    }
}
