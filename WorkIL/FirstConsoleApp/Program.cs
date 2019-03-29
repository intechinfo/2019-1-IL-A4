using System;
using System.Text;

namespace FirstConsoleApp
{
    class CUser
    {
        public string Name { get; }

        public int Power { get; set; }

        public CUser()
            : this( "Default Name" )
        {
        }

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

        // This is forbidden for performance reason.
        //public SUser()
        ////: this( "Default Name" )
        //{
        //    Power = 78;
        //    Name = "Toto";
        //}

        public SUser( string name )
        {
            Name = name;
            // For structs, all fields MUST be explicitly initialized.
            // This is not the case for class...
            Power = 0;
        }

        public override string ToString() => String.Format( " Struct {0}", Name );
    }


    class Program
    {
        static void Main( string[] args )
        {
            var cu = new CUser( "Spi" );
            var su = new SUser( "Spi" );

            var acu = new CUser[100];
            var asu = new SUser[100];




        }

    }

}
