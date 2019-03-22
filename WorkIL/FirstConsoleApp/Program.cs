using System;
using System.Text;

namespace FirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

#if NET461
            Console.WriteLine( "NET461" );
#else
            Console.WriteLine( "PAS NET461" );
#endif

#if OPTIMIZED
            Console.WriteLine( 0 );
            Console.WriteLine( 1 );
            Console.WriteLine( 2*2 );
            Console.WriteLine( 3*3 );
            Console.WriteLine( 4*4 );
            Console.WriteLine( 5*5 );
            Console.WriteLine( 6*6 );
            Console.WriteLine( 6*6 );
            Console.WriteLine( 7*7 );
#else
            for( int i = 0; i < 10; ++i )
            {
                Console.WriteLine( i*i );
            }
#endif
        }
    }

}
