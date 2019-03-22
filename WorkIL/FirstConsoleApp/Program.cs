using System;
using System.Text;

namespace FirstConsoleApp
{
    class CUser
    {
        public string Name { get; }

        public int Power { get; set; }

        public CUser( string name )
        {
            Name = name;
        }

        public override string ToString() => $" Class {Name}";
    }

    struct SUser
    {
        public string Name { get; }

        public int Power { get; set; }

        public SUser( string name )
        {
            Name = name;
        }
        public override string ToString() => String.Format( " Struct {0}", Name );
    }


    class Program
    {
        static void Main( string[] args )
        {
            var cu = new CUser( "Spi" );
            var su = new SUser( "Spi" );


        }

    }

}
