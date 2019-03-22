using System;
using System.Text;

namespace FirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ss = "noël";

            char c = ss[2];
            var cat = Char.GetUnicodeCategory( c );
        }
    }

}
